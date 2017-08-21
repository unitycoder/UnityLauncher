using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
            SetStatus("Initializing..");

            // check installations folder
            var root = GetRootFolder();
            if (string.IsNullOrEmpty(root) == true)
            {
                SetStatus("Missing root folder..");
                SetRootFolder();
                SetStatus("Ready");
            }

            // update settings window
            chkMinimizeToTaskbar.Checked = Properties.Settings.Default.minimizeToTaskbar;

            // update installations folder listbox
            lstRootFolders.Items.AddRange(Properties.Settings.Default.rootFolders.Cast<string>().ToArray());

            // scan installed unitys, TODO: could cache results, at least fileinfo's
            bool foundedUnitys = ScanUnityInstallations();
            if (foundedUnitys == false)
            {
                SetStatus("Error> Did not found any Unity installations, try setting correct root folder..");
                UpdateRecentProjectsList();
                tabControl1.SelectedIndex = 2; // settings tab
                return;
            }

            // check if received -projectPath argument (that means, should try open the project)
            string[] args = Environment.GetCommandLineArgs();
            if (args != null && args.Length > 2)
            {
                var commandArg = args[1];
                if (commandArg == "-projectPath")
                {
                    SetStatus("Launching from commandline..");

                    var pathArg = args[2];
                    //                  Console.WriteLine("\nPATH: " + pathArg);
                    LaunchProject(pathArg);
                    SetStatus("Ready");
                }
                else
                {
                    //                    Console.WriteLine("Invalid arguments:" + args[1]);
                    SetStatus("Error> Invalid arguments:" + args[1]);
                }

            }

            UpdateRecentProjectsList();
        }

        /// <summary>
        /// returns true if we have exact version installed
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        bool HaveExactVersionInstalled(string version)
        {
            //Console.WriteLine("checking: '" + version + "'");
            var installedExact = unityList.ContainsKey(version);
            //Console.WriteLine("have exact:" + installedExact);
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
                Properties.Settings.Default[_rootFolderKey] = newRoot;
                Properties.Settings.Default.Save();

                // listbox
                lstRootFolders.Items.Add(newRoot);

                SaveSettingsRootFolders();
            }
        }

        bool ScanUnityInstallations()
        {
            SetStatus("Scanning unity installations..");

            // dictionary to keep version and path
            unityList.Clear();

            // installed unitys list in other tab
            gridUnityList.Rows.Clear();

            // iterate all root folders
            foreach (string root in lstRootFolders.Items)
            {
                //                var root = GetRootFolder();
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
                                if (unityList.ContainsKey(unityVersion) == false)
                                {
                                    unityList.Add(unityVersion, unityExe);
                                    gridUnityList.Rows.Add(unityVersion, unityExe);
                                }
                                //Console.WriteLine(unityVersion);
                            } // have unity.exe
                        } // have uninstaller.exe
                    } // got folders
                } // failed check
            } // all root folders


            lbl_unityCount.Text = "Founded " + unityList.Count.ToString() + " versions";

            SetStatus("Finished scanning");

            // founded any unity installations?
            return unityList.Count > 0;
        }


        // set basefolder of all unity installations
        private void btn_setinstallfolder_Click(object sender, EventArgs e)
        {
            SetRootFolder();
            ScanUnityInstallations();
            UpdateRecentProjectsList();
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
            SetStatus("Updating recent projects list..");

            var hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            RegistryKey key = hklm.OpenSubKey(@"SOFTWARE\Unity Technologies\Unity Editor 5.x");

            //Console.WriteLine(key);
            if (key == null)
            {
                // no recent list founded
                Console.WriteLine("No recent projects list founded");
                return;
            }

            gridRecent.Rows.Clear();

            foreach (var valueName in key.GetValueNames())
            {
                if (valueName.IndexOf("RecentlyUsedProjectPaths-") == 0)
                {
                    byte[] projectPathBytes = (byte[])key.GetValue(valueName);
                    string projectPath = Encoding.Default.GetString(projectPathBytes, 0, projectPathBytes.Length - 1);
                    string projectName = projectPath.Substring(projectPath.LastIndexOf("/") + 1);

                    string csprojFile = Path.Combine(projectPath, projectName + ".csproj");

                    // editor only project
                    if (File.Exists(csprojFile) == false)
                    {
                        csprojFile = Path.Combine(projectPath, projectName + ".Editor.csproj");
                    }

                    DateTime? lastUpdated = GetLastUpdatedTime(csprojFile);

                    string projectVersion = GetProjectVersion(projectPath);
                    // TODO: could display "Today", "Yesterday", "Last week"..

                    gridRecent.Rows.Add(projectName, projectVersion, projectPath, lastUpdated);
                    //gridRecent.Rows[gridRecent.Rows.Count-1].Cells[1].Style.BackColor = HaveExactVersionInstalled(projectVersion) ?Color.Green:Color.Red;
                    gridRecent.Rows[gridRecent.Rows.Count - 1].Cells[1].Style.ForeColor = HaveExactVersionInstalled(projectVersion) ? Color.Green : Color.Red;
                }
            }

            SetStatus("Ready");
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
            LaunchSelectedProject();
        }

        void LaunchProject(string pathArg = null)
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
                        var yesno = MessageBox.Show("Unity version " + version + " is not installed! Yes = Download, No = Open Webpage", "UnityLauncher", MessageBoxButtons.YesNoCancel);

                        string url = GetUnityReleaseURL(version);

                        // download file
                        if (yesno == DialogResult.Yes)
                        {
                            Console.WriteLine("download unity: " + url);
                            if (string.IsNullOrEmpty(url) == false)
                            {
                                DownloadAndRun(url);
                            }
                        }

                        // open page
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
                    SetStatus("No Assets folder founded in: " + pathArg);
                }
            }
            else // given path doesnt exists, strange
            {
                SetStatus("Invalid Path:" + pathArg);
            }
        }

        /// <summary>
        /// downloads unity installer and launches it
        /// </summary>
        /// <param name="url"></param>
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
                    Console.WriteLine("Cannot parse exe.. opening website instead");
                    Process.Start(url);
                }
            }
        }

        /// <summary>
        /// parse unity installer filename from url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        string GetFileNameFromUrl(string url)
        {
            var uri = new Uri(url);
            var filename = uri.Segments.Last();
            return filename;
        }

        /// <summary>
        /// get rootfolder from settings, default is c:\program files\
        /// </summary>
        /// <returns></returns>
        string GetRootFolder()
        {
            string conf = null;

            // rebuild config file, since we dont want to ship it
            try
            {
                // if settings exists, use that
                conf = Properties.Settings.Default[_rootFolderKey].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // doesnt work yet?
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Save();
            }
            return conf;
        }

        private void btn_openFolder_Click(object sender, EventArgs e)
        {
            var selected = gridRecent.CurrentCell.RowIndex;
            if (selected > -1)
            {
                LaunchExplorer(gridRecent.Rows[selected].Cells["_path"].Value.ToString());
            }
        }

        /// <summary>
        /// launch windows explorer to selected project folder
        /// </summary>
        /// <param name="folder"></param>
        void LaunchExplorer(string folder)
        {
            if (Directory.Exists(folder) == true)
            {
                Process.Start(folder);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ScanUnityInstallations();
        }


        void SetStatus(string msg)
        {
            toolStripStatusLabel1.Text = msg;
            this.Refresh();
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            if (chkMinimizeToTaskbar.Checked == true)
            {
                if (FormWindowState.Minimized == this.WindowState)
                {
                    notifyIcon.Visible = true;
                    this.Hide();
                }
                else if (FormWindowState.Normal == this.WindowState)
                {
                    notifyIcon.Visible = false;
                }
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            ShowForm();
        }

        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        void LaunchSelectedProject()
        {
            var selected = gridRecent.CurrentCell.RowIndex;
            if (selected > -1)
            {
                SetStatus("Launching project..");
                LaunchProject(gridRecent.Rows[selected].Cells["_path"].Value.ToString());
                SetStatus("Ready");
            }
        }

        /// <summary>
        /// grid keys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridRecent_KeyDown(object sender, KeyEventArgs e)
        {
            //Console.WriteLine(e.KeyValue);
            switch (e.KeyCode)
            {
                case Keys.Return: // launch selected project
                    e.SuppressKeyPress = true;
                    LaunchSelectedProject();
                    break;
                case Keys.F5: // refresh recent projects list
                    UpdateRecentProjectsList();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// global keys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '1':
                    tabControl1.SelectedIndex = 0;
                    break;
                case '2':
                    tabControl1.SelectedIndex = 1;
                    break;
                case '3':
                    tabControl1.SelectedIndex = 2;
                    break;
                default:
                    break;
            }
        }

        private void unityGridView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return: // launch selected unity
                    e.SuppressKeyPress = true;
                    LaunchSelectedUnity();
                    break;
                case Keys.F5: // refresh installed unitys list
                    UpdateInstalledUnitysList();
                    break;
                default:
                    break;
            }
        }

        void LaunchSelectedUnity()
        {
            var selected = gridUnityList.CurrentCell.RowIndex;
            if (selected > -1)
            {
                SetStatus("Launching Unity..");
                var version = gridUnityList.Rows[selected].Cells["_unityVersion"].Value.ToString();
                try
                {
                    Process myProcess = new Process();
                    var cmd = "\"" + unityList[version] + "\"";
                    myProcess.StartInfo.FileName = cmd;
                    myProcess.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                SetStatus("Ready");
            }
        }

        void UpdateInstalledUnitysList()
        {
            ScanUnityInstallations();
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            SetRootFolder();
            ScanUnityInstallations();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstRootFolders.SelectedIndex > -1)
            {
                lstRootFolders.Items.RemoveAt(lstRootFolders.SelectedIndex);
                SaveSettingsRootFolders();
                ScanUnityInstallations();
            }

        }

        void SaveSettingsRootFolders()
        {
            Properties.Settings.Default.rootFolders.Clear();
            Properties.Settings.Default.rootFolders.AddRange(lstRootFolders.Items.OfType<string>().ToArray());
            Properties.Settings.Default.Save();
        }

        private void btnLaunchUnity_Click(object sender, EventArgs e)
        {
            LaunchSelectedUnity();
        }

        private void btnExploreUnity_Click(object sender, EventArgs e)
        {
            var selected = gridUnityList.CurrentCell.RowIndex;
            if (selected > -1)
            {
                var unityPath = Path.GetDirectoryName(gridUnityList.Rows[selected].Cells["_unityPath"].Value.ToString());
                LaunchExplorer(unityPath);
            }
        }

        string GetUnityReleaseURL(string version)
        {
            string url = "";
            if (version.Contains("f")) // archived
            {
                version = Regex.Replace(version, @"f.", "", RegexOptions.IgnoreCase);
                url = "https://unity3d.com/unity/whats-new/unity-" + version;
            }
            if (version.Contains("p")) // patch version
            {
                url = "https://unity3d.com/unity/qa/patch-releases/" + version;
            }
            if (version.Contains("b")) // beta version
            {
                url = "https://unity3d.com/unity/beta/unity" + version;
            }
            return url;
        }

        private void btnOpenReleasePage_Click(object sender, EventArgs e)
        {
            var selected = gridUnityList.CurrentCell.RowIndex;
            if (selected > -1)
            {
                var version = gridUnityList.Rows[selected].Cells["_unityVersion"].Value.ToString();
                var url = GetUnityReleaseURL(version);
                if (string.IsNullOrEmpty(url) == false)
                {
                    Process.Start(url);
                }
            }
        }

        private void chkMinimizeToTaskbar_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.minimizeToTaskbar = chkMinimizeToTaskbar.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
