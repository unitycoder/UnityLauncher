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

namespace UnityLauncher
{
    public partial class Form1 : Form
    {
        // version,exe path (example: 5.6.1f1,c:\prog\unity561\editor\unity.exe)
        public static Dictionary<string, string> unityList = new Dictionary<string, string>();

        const int settingsTabIndex = 3;
        const string contextRegRoot = "Software\\Classes\\Directory\\Background\\shell";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Start();
        }

        void Start()
        {
            SetStatus("Initializing..");

            // check installations folder
            var root = GetRootFolder();
            if (root == null || root.Length == 0)
            {
                SetStatus("Missing root folder..");
                AddRootFolder();
                SetStatus("Ready");
            }

            LoadSettings();

            // scan installed unitys, TODO: could cache results, at least fileinfo's
            bool foundedUnitys = ScanUnityInstallations();
            if (foundedUnitys == false)
            {
                SetStatus("Error> Did not found any Unity installations, try setting correct root folder..");
                UpdateRecentProjectsList();
                tabControl1.SelectedIndex = settingsTabIndex;
                return;
            }

            // check if received -projectPath argument (that means opening from explorer / cmdline)
            string[] args = Environment.GetCommandLineArgs();
            if (args != null && args.Length > 2)
            {
                var commandLineArgs = args[1];
                if (commandLineArgs == "-projectPath")
                {
                    SetStatus("Launching from commandline..");

                    var projectPathArgument = args[2];
                    var version = GetProjectVersion(projectPathArgument);

                    // try launching it
                    LaunchProject(projectPathArgument, version, true);

                    SetStatus("Ready");

                    // quit after launch if enabled in settings
                    if (Properties.Settings.Default.closeAfterExplorer == true)
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    SetStatus("Error> Invalid arguments:" + args[1]);
                }
            }

            UpdateRecentProjectsList();

            // preselect grid
            gridRecent.Select();
        }

        void LoadSettings()
        {
            // update settings window
            chkMinimizeToTaskbar.Checked = Properties.Settings.Default.minimizeToTaskbar;
            chkQuitAfterCommandline.Checked = Properties.Settings.Default.closeAfterExplorer;
            ChkQuitAfterOpen.Checked = Properties.Settings.Default.closeAfterProject;

            // update installations folder listbox
            lstRootFolders.Items.AddRange(Properties.Settings.Default.rootFolders.Cast<string>().ToArray());
            // update packages folder listbox
            lstPackageFolders.Items.AddRange(Properties.Settings.Default.packageFolders.Cast<string>().ToArray());
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


        void AddRootFolder()
        {
            folderBrowserDialog1.Description = "Select root folder";
            var d = folderBrowserDialog1.ShowDialog();
            var newRoot = folderBrowserDialog1.SelectedPath;

            if (String.IsNullOrWhiteSpace(newRoot) == false && Directory.Exists(newRoot) == true)
            {
                lstRootFolders.Items.Add(newRoot);
                Properties.Settings.Default.rootFolders.Add(newRoot);
                Properties.Settings.Default.Save();
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


        private string GetUnityVersion(string path)
        {
            // todo check path
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(path);
            return fvi.ProductName.Replace("(64-bit)", "").Trim();
        }

        void FilterRecentProject(object sender, EventArgs e)
        {
            SetStatus("Filtering recent projects list..");
            foreach (DataGridViewRow recentProject in gridRecent.Rows)
            {
                if (recentProject.Cells["_project"].Value.ToString().ToLower().Contains(tbSearchBar.Text.ToLower()))
                    recentProject.Visible = true;
                else recentProject.Visible = false;
            }
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
                SetStatus("No recent projects list founded");
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

        void LaunchProject(string projectPath, string version, bool openProject = true)
        {
            if (Directory.Exists(projectPath) == true)
            {
                // no assets path, probably we want to create new project then
                var assetsFolder = Path.Combine(projectPath, "Assets");
                if (Directory.Exists(assetsFolder) == false)
                {
                    // TODO could ask if want to create project..
                    Directory.CreateDirectory(assetsFolder);
                }

                // check for crashed backup scene first
                var cancelLaunch = CheckCrashBackupScene(projectPath);
                Console.WriteLine(cancelLaunch);
                if (cancelLaunch == true)
                {
                    return;
                }

                if (HaveExactVersionInstalled(version) == true)
                {
                    //Console.WriteLine("Opening unity version " + version);
                    SetStatus("Launching project in unity " + version);

                    try
                    {
                        Process myProcess = new Process();
                        var cmd = "\"" + unityList[version] + "\"";
                        myProcess.StartInfo.FileName = cmd;
                        if (openProject == true)
                        {
                            var pars = " -projectPath " + "\"" + projectPath + "\"";
                            myProcess.StartInfo.Arguments = pars;
                        }
                        myProcess.Start();

                        if (Properties.Settings.Default.closeAfterProject)
                        {
                            Environment.Exit(0);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                else // we dont have this version installed (or no version info available)
                {
                    SetStatus("Missing unity version: " + version);
                    DisplayUpgradeDialog(version, projectPath);
                }
            }
            else // given path doesnt exists, strange
            {
                SetStatus("Invalid Path: " + projectPath);
            }
        }

        bool CheckCrashBackupScene(string projectPath)
        {
            var cancelRunningUnity = false;
            var recoveryFile = Path.Combine(projectPath, "Temp", "__Backupscenes", "0.backup");
            if (File.Exists(recoveryFile))
            {
                DialogResult dialogResult = MessageBox.Show("Crash recovery scene founded, do you want to copy it into Assets/_Recovery/-folder?", "UnityLauncher - Scene Recovery", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes) // restore
                {
                    var restoreFolder = Path.Combine(projectPath, "Assets", "_Recovery");
                    if (Directory.Exists(restoreFolder) == false)
                    {
                        Directory.CreateDirectory(restoreFolder);
                    }
                    if (Directory.Exists(restoreFolder) == true)
                    {
                        Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        var uniqueFileName = "Recovered_Scene" + unixTimestamp + ".unity";
                        File.Copy(recoveryFile, Path.Combine(restoreFolder, uniqueFileName));
                        SetStatus("Recovered crashed scene into: " + restoreFolder);
                    }
                    else
                    {
                        SetStatus("Error: Failed to create restore folder: " + restoreFolder);
                        cancelRunningUnity = true;
                    }
                }
                else if (dialogResult == DialogResult.Cancel) // dont do restore, but run unity
                {
                    cancelRunningUnity = true;
                }
            }
            return cancelRunningUnity;
        }

        // parse unity installer exe from release page
        // thanks to https://github.com/softfruit
        string GetDownloadUrlForUnityVersion(string releaseUrl)
        {
            string url = "";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (WebClient client = new WebClient())
            {
                string html = client.DownloadString(releaseUrl);
                Regex regex = new Regex(@"(http).+(UnityDownloadAssistant)+[^\s*]*(.exe)");
                Match match = regex.Match(html);
                if (match.Success == true)
                {
                    url = match.Groups[0].Captures[0].Value;
                    //                    Console.WriteLine(url);
                }
                else
                {
                    SetStatus("Cannot find UnityDownloadAssistant.exe for this version..");
                }
            }
            return url;
        }

        /// <summary>
        /// downloads unity installer and launches it
        /// </summary>
        /// <param name="url"></param>
        void DownloadAndRun(string url)
        {
            string exeURL = GetDownloadUrlForUnityVersion(url);

            if (string.IsNullOrEmpty(exeURL) == false)
            {
                SetStatus("Download installer: " + exeURL);
                // download temp file
                using (WebClient downloader = new WebClient())
                {
                    var f = GetFileNameFromUrl(exeURL);
                    FileInfo fileInfo = new FileInfo(f);
                    downloader.DownloadFile(exeURL, f);
                    if (File.Exists(fileInfo.FullName))
                    {
                        SetStatus("Running installer");
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
                            SetStatus("Failed running installer");
                        }

                    }
                }
                SetStatus("Finished Running installer");
            }
            else // not found
            {
                SetStatus("Error> Cannot find installer exe.. opening website instead");
                Process.Start(url + "#installer-exe-not-found");
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
        string[] GetRootFolder()
        {
            string[] rootFolders = null;
            try
            {
                // if settings exists, use that
                rootFolders = new string[Properties.Settings.Default.rootFolders.Count];
                Properties.Settings.Default.rootFolders.CopyTo(rootFolders, 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // this doesnt work?
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Save();
            }
            return rootFolders;
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
            else
            {
                SetStatus("Error> Directory not found: " + folder);
            }
        }

        void SetStatus(string msg)
        {
            toolStripStatusLabel1.Text = msg;
            this.Refresh();
        }

        private void ShowForm()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        void LaunchSelectedProject(bool openProject = true)
        {
            var selected = gridRecent.CurrentCell.RowIndex;
            if (selected > -1)
            {
                SetStatus("Launching project..");
                var projectPath = gridRecent.Rows[selected].Cells["_path"].Value.ToString();
                var version = GetProjectVersion(projectPath);
                LaunchProject(projectPath, version, openProject);
                SetStatus("Ready");
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

        void AddPackageFolder()
        {
            folderBrowserDialog1.Description = "Select package folder";
            var d = folderBrowserDialog1.ShowDialog();
            var newPackageFolder = folderBrowserDialog1.SelectedPath;

            if (String.IsNullOrWhiteSpace(newPackageFolder) == false && Directory.Exists(newPackageFolder) == true)
            {
                lstPackageFolders.Items.Add(newPackageFolder);
                Properties.Settings.Default.packageFolders.Add(newPackageFolder);
                Properties.Settings.Default.Save();
            }
        }

        void AddContextMenuRegistry()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(contextRegRoot, true);
            if (key != null)
            {
                var appName = "UnityLauncher";
                key.CreateSubKey(appName);

                key = key.OpenSubKey(appName, true);
                key.SetValue("", "Open with UnityLauncher");
                key.SetValue("Icon", "\"" + Application.ExecutablePath + "\"");

                key.CreateSubKey("command");
                key = key.OpenSubKey("command", true);
                var executeString = "\"" + Application.ExecutablePath + "\"";
                executeString += " -projectPath \"%V\"";
                key.SetValue("", executeString);
                SetStatus("Added context menu registry items");
            }
            else
            {
                SetStatus("Error> Cannot find registry key: " + contextRegRoot);
            }
        }

        void RemoveContextMenuRegistry()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(contextRegRoot, true);
            if (key != null)
            {
                var appName = "UnityLauncher";
                RegistryKey appKey = Registry.CurrentUser.OpenSubKey(contextRegRoot + "\\" + appName, false);
                if (appKey != null)
                {
                    key.DeleteSubKeyTree(appName);
                    SetStatus("Removed context menu registry items");
                }
                else
                {
                    SetStatus("Nothing to uninstall..");
                }
            }
            else
            {
                SetStatus("Error> Cannot find registry key: " + contextRegRoot);
            }
        }

        #region Buttons and UI events

        private void btnRemoveRegister_Click(object sender, EventArgs e)
        {
            RemoveContextMenuRegistry();
        }

        private void chkMinimizeToTaskbar_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.minimizeToTaskbar = chkMinimizeToTaskbar.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnAddPackageFolder_Click(object sender, EventArgs e)
        {
            AddPackageFolder();
        }

        private void btnRemovePackFolder_Click(object sender, EventArgs e)
        {
            if (lstPackageFolders.SelectedIndex > -1)
            {
                lstPackageFolders.Items.RemoveAt(lstPackageFolders.SelectedIndex);
            }
        }

        private void btnOpenReleasePage_Click(object sender, EventArgs e)
        {
            var selected = gridUnityList.CurrentCell.RowIndex;
            if (selected > -1)
            {
                var version = gridUnityList.Rows[selected].Cells["_unityVersion"].Value.ToString();
                OpenReleaseNotes(version);
            }
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

        private void btnAddUnityFolder_Click(object sender, EventArgs e)
        {
            AddRootFolder();
            ScanUnityInstallations();
        }

        private void btnRemoveInstallFolder_Click(object sender, EventArgs e)
        {
            if (lstRootFolders.SelectedIndex > -1)
            {
                Properties.Settings.Default.rootFolders.Remove(lstRootFolders.Items[lstRootFolders.SelectedIndex].ToString());
                Properties.Settings.Default.Save();
                lstRootFolders.Items.RemoveAt(lstRootFolders.SelectedIndex);
                ScanUnityInstallations();
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
                    ScanUnityInstallations();
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
                case '4':
                    tabControl1.SelectedIndex = 3;
                    break;
                default:
                    if (!tbSearchBar.Focused)
                    {
                        tbSearchBar.Focus();
                        tbSearchBar.Text += e.KeyChar;
                        tbSearchBar.Select(tbSearchBar.Text.Length, 0);
                    }
                    break;
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

        //Checks if you are doubleclicking the current cell
        private void GridRecent_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex == gridRecent.CurrentCell.RowIndex)
            {
                LaunchSelectedProject();
            }
        }

        // set basefolder of all unity installations
        private void btn_setinstallfolder_Click(object sender, EventArgs e)
        {
            AddRootFolder();
            ScanUnityInstallations();
            UpdateRecentProjectsList();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            LaunchSelectedProject();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ScanUnityInstallations();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            ShowForm();
        }

        private void btn_openFolder_Click(object sender, EventArgs e)
        {
            var selected = gridRecent.CurrentCell.RowIndex;
            if (selected > -1)
            {
                LaunchExplorer(gridRecent.Rows[selected].Cells["_path"].Value.ToString());
            }
        }

        private void btnExplorePackageFolder_Click(object sender, EventArgs e)
        {
            var selected = lstPackageFolders.SelectedIndex;
            //Console.WriteLine(lstPackageFolders.Items[selected].ToString());
            if (selected > -1)
            {
                var path = lstPackageFolders.Items[selected].ToString();
                LaunchExplorer(path);
            }
        }

        private void btnAddAssetStoreFolder_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Unity", "Asset Store-5.x");
            if (Directory.Exists(path) == true)
            {
                if (lstPackageFolders.Items.Contains(path) == false)
                {
                    lstPackageFolders.Items.Add(path);
                    Properties.Settings.Default.packageFolders.Add(path);
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void btnAddRegister_Click(object sender, EventArgs e)
        {
            AddContextMenuRegistry();
        }

        private void ChkQuitAfterOpen_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.closeAfterProject = ChkQuitAfterOpen.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkQuitAfterCommandline_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.closeAfterExplorer = chkQuitAfterCommandline.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnRunUnityOnly_Click(object sender, EventArgs e)
        {
            LaunchSelectedProject(openProject: false);
        }

        private void btnUpgradeProject_Click(object sender, EventArgs e)
        {
            UpgradeProject();
        }

        private void btnOpenLogFolder_Click(object sender, EventArgs e)
        {
            var logfolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Unity", "Editor");
            //Console.WriteLine(logfolder);
            if (Directory.Exists(logfolder) == true)
            {
                LaunchExplorer(logfolder);
            }
        }
        #endregion UI events

        void OpenReleaseNotes(string version)
        {
            SetStatus("Opening release notes for version " + version);
            var url = GetUnityReleaseURL(version);
            if (string.IsNullOrEmpty(url) == false)
            {
                Process.Start(url);
            }
            else
            {
                SetStatus("Failed opening Release Notes URL for version " + version);
            }
        }

        public static string FindNearestVersion(string version, List<string> allAvailable)
        {
            if (version.Contains("2017"))
            {
                return FindNearestVersionFromSimilarVersions(version, allAvailable.Where(x => x.Contains("2017")));
            }
            return FindNearestVersionFromSimilarVersions(version, allAvailable.Where(x => !x.Contains("2017")));
        }

        private static string FindNearestVersionFromSimilarVersions(string version, IEnumerable<string> allAvailable)
        {
            Dictionary<string, string> stripped = new Dictionary<string, string>();
            var enumerable = allAvailable as string[] ?? allAvailable.ToArray();

            foreach (var t in enumerable)
            {
                stripped.Add(new Regex("[a-zA-z]").Replace(t, "."), t);
            }

            var comparableVersion = new Regex("[a-zA-z]").Replace(version, ".");
            if (!stripped.ContainsKey(comparableVersion))
            {
                stripped.Add(comparableVersion, version);
            }

            var comparables = stripped.Keys.OrderBy(x => x).ToList();
            var actualIndex = comparables.IndexOf(comparableVersion);

            if (actualIndex < stripped.Count - 1) return stripped[comparables[actualIndex + 1]];
            return null;
        }

        // displays version selector to upgrade project
        void UpgradeProject()
        {
            var selected = gridRecent.CurrentCell.RowIndex;
            if (selected > -1)
            {
                SetStatus("Upgrading project..");

                var projectPath = gridRecent.Rows[selected].Cells["_path"].Value.ToString();
                var currentVersion = GetProjectVersion(projectPath);

                if (string.IsNullOrEmpty(currentVersion) == true)
                {
                    // TODO no version info available, should handle errors?
                }
                else // have version info
                {
                    bool haveExactVersion = HaveExactVersionInstalled(currentVersion);
                    if (haveExactVersion == true)
                    {
                        // you already have exact version, are you sure about upgrade?
                    }
                }
                DisplayUpgradeDialog(currentVersion, projectPath, true);
            }
        }

        void DisplayUpgradeDialog(string currentVersion, string projectPath, bool launchProject = true)
        {
            // display upgrade dialog (version selector)
            Form2 upgradeDialog = new Form2();
            Form2.currentVersion = currentVersion;

            // check what user selected
            var results = upgradeDialog.ShowDialog(this);
            switch (results)
            {
                case DialogResult.Ignore: // view release notes page
                    OpenReleaseNotes(currentVersion);
                    // display window again for now..
                    DisplayUpgradeDialog(currentVersion, projectPath, launchProject);
                    break;
                case DialogResult.Cancel: // cancelled
                    SetStatus("Cancelled project upgrade");
                    break;
                case DialogResult.Retry: // download and install missing version
                    SetStatus("Download and Install missing version " + currentVersion);
                    string url = GetUnityReleaseURL(currentVersion);
                    if (string.IsNullOrEmpty(url) == false)
                    {
                        DownloadAndRun(url);
                    }
                    else
                    {
                        SetStatus("Failed getting Unity Installer URL");
                    }
                    break;
                case DialogResult.Yes: // upgrade
                    SetStatus("Upgrading project to " + Form2.currentVersion);
                    if (launchProject == true) LaunchProject(projectPath, Form2.currentVersion);
                    break;
                default:
                    Console.WriteLine("Unknown DialogResult: " + results);
                    break;
            }
            upgradeDialog.Close();
        }
    }
}
