using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TODO: starred projects (keep on top?)


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
            else // no args, just show window
            {
                UpdateRecentProjectsList();
                return;
            }
        }

        bool OpenWithSuitableVersion(string version)
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
                            unityList.Add(unityVersion, unityExe);
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
                    string lastUpdated = GetLastUpdatedTime(Path.Combine(projectPath, projectName + ".csproj"));

                    string projectVersion = GetProjectVersion(projectPath);
                    // TODO: could display "Today", "Yesterday", "Last week"..

                    gridRecent.Rows.Add(projectName, projectVersion, projectPath, lastUpdated);
                }
            }
        }

        string GetLastUpdatedTime(string path)
        {
            if (File.Exists(path) == true)
            {
                DateTime modification = File.GetLastWriteTime(path);
                return modification.ToShortDateString();
            }
            else
            {
                return "-";
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            var selected = gridRecent.CurrentCell.RowIndex;
            if (selected > -1)
            {
                LaunchProject(gridRecent.Rows[selected].Cells["_path"].Value.ToString());
            }
            //Console.WriteLine(selected);

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

                    bool installed = OpenWithSuitableVersion(version);
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
                        //throw new Exception("Unity version " + version + " is not installed!");
                        var yesno = MessageBox.Show("Unity version " + version + " is not installed!", "UnityLauncher", MessageBoxButtons.YesNo);
                        if (yesno == DialogResult.Yes)
                        {
                            Console.WriteLine("download unity..");
                            if (version.Contains("f")) // archived
                            {
                                Process.Start("https://unity3d.com/unity/whats-new/unity-" + version.Replace("f1", ""));
                            }
                            if (version.Contains("p")) // patch version
                            {
                                Process.Start("https://unity3d.com/unity/qa/patch-releases/" + version);
                            }
                            if (version.Contains("b")) // beta version
                            {
                                Process.Start("https://unity3d.com/unity/beta/unity" + version);
                            }
                        }
                    }
                }
                else
                {
                    throw new DirectoryNotFoundException("No Assets folder founded in: " + pathArg);
                }
            }
            else // given path doesnt exists, strange
            {
                throw new DirectoryNotFoundException("Invalid Path:" + pathArg);
            }

        }

        string GetRootFolder()
        {
            return Properties.Settings.Default[_rootFolderKey].ToString();
        }


    }
}
