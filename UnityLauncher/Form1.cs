using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

// TODO: FindNearestBestVersion(), so that no need to be exact match
// TODO: starred projects (keep on top and save to own list?)

namespace UnityLauncher
{
    public partial class Form1 : Form
    {
        // settings keys
        readonly static string _rootFolderKey = "rootFolder";

        // version,exe path (example: 5.6.1f1,c:\prog\unity561\editor\unity.exe)
        Dictionary<string, string> unityList = new Dictionary<string, string>();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var root = GetRootFolder();
            txtRootFolder.Text = root;

            if (string.IsNullOrEmpty(root) == true)
            {
                // we dont have root folder set, ask to set, TODO: no alert boxes
                var confirmResult = MessageBox.Show("Installation root folder is not set..", "UnityLauncher", MessageBoxButtons.OK);
                return;
            }

            // scan installed unitys, TODO: could cache results, at least fileinfo's
            bool foundedUnitys = ScanUnityInstallations();
            if (foundedUnitys == true)
            {
                // ok
            }
            else
            {
                // TODO: no alert box..just message in the form
                var confirmResult = MessageBox.Show("Did not found any Unity installations, try setting correct root folder..", "UnityLauncher", MessageBoxButtons.OK);
                return;
            }

            // check if received any arguments (that means, should try open the project)
            string[] args = Environment.GetCommandLineArgs();
            if (args != null && args.Length > 1)
            {
                var pathArg = args[1];
                Console.WriteLine("\nPATH: " + pathArg);
                Console.WriteLine("");
                LaunchProject(pathArg);
            }

            // this could be delayed, if it affects unity starting?
            UpdateRecentProjectsList();
        }

        bool HaveExactVersionInstalled(string version)
        {
            // check if got exact hit
            Console.WriteLine("checking: '" + version + "'");

            var installedExact = unityList.ContainsKey(version);
            Console.WriteLine("have exact:" + installedExact);

            return installedExact;
        }


        // read and parse project settings file
        string GetProjectVersion(string path)
        {
            var version = "";
            if (Directory.Exists(Path.Combine(path, "ProjectSettings")))
            {
                var versionPath = Path.Combine(path, "ProjectSettings", "ProjectVersion.txt");
                if (File.Exists(versionPath) == true)
                {
                    var data = File.ReadAllLines(versionPath);

                    if (data != null && data.Length > 0)
                    {
                        var dd = data[0];
                        // check first line
                        if (dd.Contains("m_EditorVersion"))
                        {
                            var t = dd.Split(new string[] { "m_EditorVersion: " }, StringSplitOptions.None);
                            if (t != null && t.Length > 0)
                            {
                                version = t[1].Trim();
                            }
                            else
                            {
                                throw new InvalidDataException("invalid version data:" + data);
                            }
                        }
                        else
                        {
                            throw new InvalidDataException("Cannot find m_EditorVersion:" + dd);
                        }
                    }
                    else
                    {
                        throw new InvalidDataException("invalid projectversion data:" + data.ToString());
                    }
                }
            }
            return version;
        }


        void SetRootFolder()
        {
            var d = folderBrowserDialog1.ShowDialog();
            var newRoot = folderBrowserDialog1.SelectedPath;

            if (String.IsNullOrWhiteSpace(newRoot) == false && Directory.Exists(newRoot) == true)
            {
                txtRootFolder.Text = newRoot;
                Properties.Settings.Default[_rootFolderKey] = newRoot;
                Properties.Settings.Default.Save();
            }
        }

        bool ScanUnityInstallations()
        {
            unityList.Clear();

            var root = GetRootFolder();

            if (String.IsNullOrWhiteSpace(root) == false && Directory.Exists(root) == true)
            {
                // parse all folders here, and search for unity editor files
                var directories = Directory.GetDirectories(root);
                for (int i = 0, length = directories.Length; i < length; i++)
                {
                    var uninstallExe = Path.Combine(directories[i], "Editor", "Uninstall.exe");
                    if (File.Exists(uninstallExe) == true)
                    {
                        var unityExe = Path.Combine(directories[i], "Editor", "Unity.exe");
                        if (File.Exists(uninstallExe) == true)
                        {
                            var unityVersion = GetUnityVersion(uninstallExe).Replace("Unity", "").Trim();
                            if (unityList.ContainsKey(unityVersion)==false)
                            {
                                unityList.Add(unityVersion, unityExe);
                            }
                            //Console.WriteLine(unityVersion);
                        } // have unity.exe
                    } // have uninstaller.exe
                } // got folders
            } // didnt select anything


            lbl_unityCount.Text = "Founded " + unityList.Count.ToString() + " versions";

            // founded any unity installations?
            return unityList.Count > 0;
        }


        // set basefolder of all unity installations
        private void btn_setinstallfolder_Click(object sender, EventArgs e)
        {
            SetRootFolder();
            ScanUnityInstallations();
        }

        private string GetUnityVersion(string path)
        {
            // todo check path
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(path);
            return fvi.ProductName.Replace("(64-bit)", "").Trim();
        }


        // returns already sorted list of recent entries
        void UpdateRecentProjectsList()
        {
            var hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            RegistryKey key = hklm.OpenSubKey(@"SOFTWARE\Unity Technologies\Unity Editor 5.x");

            //Console.WriteLine(key);
            if (key == null)
            {
                // no recent list founded
                Console.WriteLine("No recent projects list founded");
                return;
            }

            foreach (var valueName in key.GetValueNames())
            {
                if (valueName.IndexOf("RecentlyUsedProjectPaths-") == 0)
                {
                    byte[] projectPathBytes = (byte[])key.GetValue(valueName);
                    string projectPath = Encoding.Default.GetString(projectPathBytes, 0, projectPathBytes.Length - 1);
                    string projectName = projectPath.Substring(projectPath.LastIndexOf("/") + 1);

                    string csprojFile = Path.Combine(projectPath, projectName + ".csproj");

                    // editor only project
                    if (File.Exists(csprojFile)==false)
                    {
                        csprojFile = Path.Combine(projectPath, projectName + ".Editor.csproj");
                    }

                    DateTime? lastUpdated = GetLastUpdatedTime(csprojFile);

                    string projectVersion = GetProjectVersion(projectPath);
                    // TODO: could display "Today", "Yesterday", "Last week"..

                    gridRecent.Rows.Add(projectName, projectVersion, projectPath, lastUpdated);
                    //gridRecent.Rows[gridRecent.Rows.Count-1].Cells[1].Style.BackColor = HaveExactVersionInstalled(projectVersion) ?Color.Green:Color.Red;
                    gridRecent.Rows[gridRecent.Rows.Count-1].Cells[1].Style.ForeColor = HaveExactVersionInstalled(projectVersion) ?Color.Green:Color.Red;
                }
            }
        }

        DateTime? GetLastUpdatedTime(string path)
        {
            if (File.Exists(path) == true)
            {
                DateTime modification = File.GetLastWriteTime(path);
                //return modification.ToShortDateString();
                return modification;
            }
            else
            {
                return null;
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            var selected = gridRecent.CurrentCell.RowIndex;
            if (selected > -1)
            {
                LaunchProject(gridRecent.Rows[selected].Cells["_path"].Value.ToString());
            }
        }

        void LaunchProject(string pathArg)
        {
            // check if path is unity project folder
            if (Directory.Exists(pathArg) == true)
            {
                // validate folder
                if (Directory.Exists(Path.Combine(pathArg, "Assets")))
                {
                    var version = GetProjectVersion(pathArg);
                    Console.WriteLine("Detected project version: " + version);

                    bool installed = HaveExactVersionInstalled(version);
                    if (installed == true)
                    {
                        // TODO: open?
                        Console.WriteLine("Opening unity version " + version);

                        try
                        {
                            Process myProcess = new Process();

                            var cmd = "\"" + unityList[version] + "\"";
                            var pars = " -projectPath " + "\"" + pathArg + "\"";

                            Console.WriteLine("execute: " + cmd);

                            myProcess.StartInfo.FileName = cmd;
                            myProcess.StartInfo.Arguments = pars;
                            myProcess.Start();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }

                    }
                    else
                    {
                        // TODO: offer to download and run installer from that page!

                        var yesno = MessageBox.Show("Unity version " + version + " is not installed! Yes = Download, No = Open Webpage", "UnityLauncher", MessageBoxButtons.YesNoCancel);
                        string url = "";

                        if (version.Contains("f")) // archived
                        {
                            url = "https://unity3d.com/unity/whats-new/unity-" + version.Replace("f1", "");
                        }
                        if (version.Contains("p")) // patch version
                        {
                            url = "https://unity3d.com/unity/qa/patch-releases/" + version;
                        }
                        if (version.Contains("b")) // beta version
                        {
                            url = "https://unity3d.com/unity/beta/unity" + version;
                        }

                        if (yesno == DialogResult.Yes)
                        {
                            Console.WriteLine("download unity: " + url);
                            if (string.IsNullOrEmpty(url) == false)
                            {
                                DownloadAndRun(url);
                            }
                        }

                        if (yesno == DialogResult.No)
                        {
                            if (string.IsNullOrEmpty(url) == false)
                            {
                                Process.Start(url);
                            }
                        }
                    }
                }
                else
                {
                    // TODO: display error in ui
                    throw new DirectoryNotFoundException("No Assets folder founded in: " + pathArg);
                }
            }
            else // given path doesnt exists, strange
            {
                // TODO: display error in ui
                throw new DirectoryNotFoundException("Invalid Path:" + pathArg);
            }

        }


        void DownloadAndRun(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (WebClient client = new WebClient())
            {
                string html = client.DownloadString(url);

                string foundedURL = "";
                var allLines = html.Split('\n');
                for (int i = 0, length = allLines.Length; i < length; i++)
                {
                    if (allLines[i].Contains("UnityDownloadAssistant") && allLines[i].Contains(".exe"))
                    {
                        var dlURL = allLines[i].Split('\"');
                        if (dlURL.Length > 1)
                        {
                            Console.WriteLine(dlURL[1]);
                            foundedURL = dlURL[1];
                            break;
                        }
                        break;
                    }
                }

                if (string.IsNullOrEmpty(foundedURL) == false)
                {
                    // download temp file
                    using (WebClient downloader = new WebClient())
                    {
                        var f = GetFileNameFromUrl(foundedURL);
                        FileInfo fileInfo = new FileInfo(f);
                        downloader.DownloadFile(foundedURL, f);
                        if (File.Exists(fileInfo.FullName))
                        {
                            try
                            {
                                Process myProcess = new Process();
                                myProcess.StartInfo.FileName = fileInfo.FullName;
                                myProcess.Start();
                                myProcess.WaitForExit();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }

                        }
                    }
                }
                else // not found
                {
                    Process.Start(url);
                    Console.WriteLine("Cannot parse exe.. opening website instead");
                }
            }
        }

        string GetFileNameFromUrl(string url)
        {
            var uri = new Uri(url);
            var filename = uri.Segments.Last();
            return filename;
        }

        string GetRootFolder()
        {
            return Properties.Settings.Default[_rootFolderKey].ToString();
        }

        private void btn_openFolder_Click(object sender, EventArgs e)
        {
            var selected = gridRecent.CurrentCell.RowIndex;
            if (selected > -1)
            {
                LaunchExplorer(gridRecent.Rows[selected].Cells["_path"].Value.ToString());
            }
        }

        void LaunchExplorer(string folder)
        {
            if (Directory.Exists(folder)==true)
            {
                Process.Start(folder);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ScanUnityInstallations();
        }


        /*
        private void gridRecent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("asdfasdfasdfas");
            LaunchProject(gridRecent.Rows[e.RowIndex].Cells["_path"].Value.ToString());
        }*/
    }
}
