using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UnityLauncherTools;

namespace UnityLauncher
{
    public partial class Form1 : Form
    {
        public static Dictionary<string, string> unityList = new Dictionary<string, string>();
        const string contextRegRoot = "Software\\Classes\\Directory\\Background\\shell";
        const string launcherArgumentsFile = "LauncherArguments.txt";
        const string githubReleaseAPICheckURL = "https://api.github.com/repos/unitycoder/unitylauncher/releases/latest";
        const string githubReleasesLinkURL = "https://github.com/unitycoder/UnityLauncher/releases";

        bool isDownloadingUnityList = false;
        string previousGitRelease = "0";


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
            SetStatus("Initializing ...");
            // check installations folder
            var root = GetUnityInstallationsRootFolder();
            if (root == null || root.Length == 0)
            {
                SetStatus("Missing root folder ...");
                AddUnityInstallationRootFolder();
                SetStatus("Ready");
            }

            LoadSettings();

            // scan installed unitys
            bool foundUnitys = ScanUnityInstallations();
            if (foundUnitys == false)
            {
                SetStatus("Error> Did not find any Unity installations, try setting correct root folder ...");
                UpdateRecentProjectsList();
                tabControl1.SelectedIndex = tabControl1.TabCount - 1; // last tab is settings
                return;
            }

            // check if received -projectPath argument (that means opening from explorer / cmdline)
            string[] args = Environment.GetCommandLineArgs();
            if (args != null && args.Length > 2)
            {
                // first argument needs to be -projectPath
                var commandLineArgs = args[1];
                if (commandLineArgs == "-projectPath")
                {
                    SetStatus("Launching from commandline ...");

                    // path
                    var projectPathArgument = args[2];

                    // resolve full path if path parameter isn't a rooted path
                    if (!Path.IsPathRooted(projectPathArgument))
                    {
                        projectPathArgument = Directory.GetCurrentDirectory() + projectPathArgument;
                    }

                    var version = Tools.GetProjectVersion(projectPathArgument);

                    // take extra arguments also
                    var commandLineArguments = "";
                    for (int i = 3, len = args.Length; i < len; i++)
                    {
                        commandLineArguments += " " + args[i];
                    }

                    // try launching it
                    LaunchProject(projectPathArgument, version, openProject: true, commandLineArguments: commandLineArguments);

                    // quit after launch if enabled in settings
                    if (Properties.Settings.Default.closeAfterExplorer == true)
                    {
                        Application.Exit();
                    }

                    SetStatus("Ready");
                }
                else
                {
                    SetStatus("Error> Invalid arguments:" + args[1]);
                }
            }

            UpdateRecentProjectsList();

            // preselect grid
            gridRecent.Select();

            // get previous version build info string
            // this string is release tag for latest release when this app was compiled
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("UnityLauncher." + "PreviousVersion.txt"))
            using (StreamReader reader = new StreamReader(stream))
            {
                previousGitRelease = reader.ReadToEnd().Trim();
            }
        }

        void LoadSettings()
        {
            // form size
            this.Width = Properties.Settings.Default.formWidth;
            this.Height = Properties.Settings.Default.formHeight;

            // update settings window
            chkMinimizeToTaskbar.Checked = Properties.Settings.Default.minimizeToTaskbar;
            chkQuitAfterCommandline.Checked = Properties.Settings.Default.closeAfterExplorer;
            ChkQuitAfterOpen.Checked = Properties.Settings.Default.closeAfterProject;
            chkShowLauncherArgumentsColumn.Checked = Properties.Settings.Default.showArgumentsColumn;
            chkShowGitBranchColumn.Checked = Properties.Settings.Default.showGitBranchColumn;
            chkDarkSkin.Checked = Properties.Settings.Default.useDarkSkin;

            // update optional grid columns, hidden or visible
            gridRecent.Columns["_launchArguments"].Visible = chkShowLauncherArgumentsColumn.Checked;
            gridRecent.Columns["_gitBranch"].Visible = chkShowGitBranchColumn.Checked;

            // update installations folder listbox
            lstRootFolders.Items.Clear();
            lstRootFolders.Items.AddRange(Properties.Settings.Default.rootFolders.Cast<string>().ToArray());
            // update packages folder listbox
            lstPackageFolders.Items.AddRange(Properties.Settings.Default.packageFolders.Cast<string>().ToArray());

            // restore data grid view widths
            int[] gridColumnWidths = Properties.Settings.Default.gridColumnWidths;
            if (gridColumnWidths != null)
            {

                for (int i = 0; i < gridColumnWidths.Length; ++i)
                {
                    gridRecent.Columns[i].Width = gridColumnWidths[i];
                }
            }

            // TODO assign colors for dark theme
            if (chkDarkSkin.Checked == true)
            {
                var darkBg = Color.FromArgb(32, 37, 41);
                var darkRaised = Color.FromArgb(50, 56, 61);
                var darkBright = Color.FromArgb(161, 180, 196);


                this.BackColor = darkBg;
                tabProjects.BackColor = darkRaised;
                gridRecent.BackgroundColor = darkRaised;

                gridRecent.GridColor = darkBg;
                var dgs = new DataGridViewCellStyle();
                dgs.BackColor = darkRaised;
                dgs.ForeColor = darkBright;
                gridRecent.DefaultCellStyle = dgs;

                statusStrip1.BackColor = darkRaised;
            }
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


        void AddUnityInstallationRootFolder()
        {
            folderBrowserDialog1.Description = "Select Unity installations root folder";
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
            SetStatus("Scanning Unity installations ...");

            // dictionary to keep version and path
            unityList.Clear();

            // installed unitys list in other tab
            gridUnityList.Rows.Clear();

            // iterate all root folders
            foreach (string root in lstRootFolders.Items)
            {
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
                                var unityVersion = Tools.GetFileVersionData(uninstallExe).Replace("Unity", "").Trim();
                                if (unityList.ContainsKey(unityVersion) == false)
                                {
                                    unityList.Add(unityVersion, unityExe);
                                    var dataFolder = Path.Combine(directories[i], "Editor", "Data");
                                    DateTime? installDate = Tools.GetLastModifiedTime(dataFolder);
                                    // TODO add platforms: PC|iOS|tvOS|Android|UWP|WebGL|Facebook|XBox|PSVita|PS4
                                    gridUnityList.Rows.Add(unityVersion, unityExe, installDate);
                                }
                            } // have unity.exe
                        } // have uninstaller.exe
                    } // got folders
                } // failed check
            } // all root folders


            lbl_unityCount.Text = "Found " + unityList.Count.ToString() + " versions";

            SetStatus("Finished scanning");

            // found any Unity installations?
            return unityList.Count > 0;
        }


        void FilterRecentProject(object sender, EventArgs e)
        {
            SetStatus("Filtering recent projects list ...");
            string searchString = tbSearchBar.Text;
            foreach (DataGridViewRow row in gridRecent.Rows)
            {
                if (row.Cells["_project"].Value.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) > -1)
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        void FilterUnityUpdates(object sender, EventArgs e)
        {
            SetStatus("Filtering Unity updates list ...");
            string searchString = tbSearchUpdates.Text;
            foreach (DataGridViewRow row in gridUnityUpdates.Rows)
            {
                if (row.Cells["_UnityUpdateVersion"].Value.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) > -1)
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        /// <summary>
        /// scans registry for recent projects and adds to project grid list
        /// </summary>
        void UpdateRecentProjectsList()
        {
            SetStatus("Updating recent projects list ...");

            gridRecent.Rows.Clear();

            var hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            string[] registryPathsToCheck = new string[] { @"SOFTWARE\Unity Technologies\Unity Editor 5.x", @"SOFTWARE\Unity Technologies\Unity Editor 4.x" };

            // check each version path
            for (int i = 0, len = registryPathsToCheck.Length; i < len; i++)
            {
                RegistryKey key = hklm.OpenSubKey(registryPathsToCheck[i]);

                if (key == null)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Null registry key at " + registryPathsToCheck[i]);
                }

                // parse recent project path
                foreach (var valueName in key.GetValueNames())
                {
                    if (valueName.IndexOf("RecentlyUsedProjectPaths-") == 0)
                    {
                        string projectPath = "";
                        // check if binary or not
                        var valueKind = key.GetValueKind(valueName);
                        if (valueKind == RegistryValueKind.Binary)
                        {
                            byte[] projectPathBytes = (byte[])key.GetValue(valueName);
                            projectPath = Encoding.UTF8.GetString(projectPathBytes, 0, projectPathBytes.Length - 1);
                        }
                        else // should be string then
                        {
                            projectPath = (string)key.GetValue(valueName);
                        }

                        // first check if whole folder exists, if not, skip
                        if (Directory.Exists(projectPath) == false)
                        {
                            Console.WriteLine("Recent project directory not found, skipping: " + projectPath);
                            continue;
                        }

                        string projectName = "";

                        // get project name from full path
                        if (projectPath.IndexOf(Path.DirectorySeparatorChar) > -1)
                        {
                            projectName = projectPath.Substring(projectPath.LastIndexOf(Path.DirectorySeparatorChar) + 1);
                        }
                        else if (projectPath.IndexOf(Path.AltDirectorySeparatorChar) > -1)
                        {
                            projectName = projectPath.Substring(projectPath.LastIndexOf(Path.AltDirectorySeparatorChar) + 1);
                        }
                        else // no path separator found
                        {
                            projectName = projectPath;
                        }

                        string csprojFile = Path.Combine(projectPath, projectName + ".csproj");

                        // solution only
                        if (File.Exists(csprojFile) == false)
                        {
                            csprojFile = Path.Combine(projectPath, projectName + ".sln");
                        }

                        // editor only project
                        if (File.Exists(csprojFile) == false)
                        {
                            csprojFile = Path.Combine(projectPath, projectName + ".Editor.csproj");
                        }

                        // maybe 4.x project
                        if (File.Exists(csprojFile) == false)
                        {
                            csprojFile = Path.Combine(projectPath, "Assembly-CSharp.csproj");
                        }

                        // get last modified date
                        DateTime? lastUpdated = Tools.GetLastModifiedTime(csprojFile);

                        // get project version
                        string projectVersion = Tools.GetProjectVersion(projectPath);

                        // get custom launch arguments, only if column in enabled
                        string customArgs = "";
                        if (chkShowLauncherArgumentsColumn.Checked == true)
                        {
                            customArgs = Tools.ReadCustomLaunchArguments(projectPath, launcherArgumentsFile);
                        }

                        // get git branchinfo, only if column in enabled
                        string gitBranch = "";
                        if (chkShowGitBranchColumn.Checked == true)
                        {
                            gitBranch = Tools.ReadGitBranchInfo(projectPath);
                        }

                        gridRecent.Rows.Add(projectName, projectVersion, projectPath, lastUpdated, customArgs, gitBranch);
                        gridRecent.Rows[gridRecent.Rows.Count - 1].Cells[1].Style.ForeColor = HaveExactVersionInstalled(projectVersion) ? Color.Green : Color.Red;
                    }
                }
            }
            SetStatus("Ready");
        }

        void LaunchProject(string projectPath, string version, bool openProject = true, string commandLineArguments = "")
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

                // when opening project, check for crashed backup scene first
                if (openProject == true)
                {
                    var cancelLaunch = CheckCrashBackupScene(projectPath);
                    if (cancelLaunch == true)
                    {
                        return;
                    }
                }

                if (HaveExactVersionInstalled(version) == true)
                {
                    if (openProject == true)
                    {
                        SetStatus("Launching project in Unity " + version);
                    }
                    else
                    {
                        SetStatus("Launching Unity " + version);
                    }

                    try
                    {
                        Process myProcess = new Process();
                        var cmd = "\"" + unityList[version] + "\"";
                        myProcess.StartInfo.FileName = cmd;
                        if (openProject == true)
                        {
                            var pars = " -projectPath " + "\"" + projectPath + "\"";

                            // check for custom launch parameters and append them
                            string customArguments = GetSelectedRowData("_launchArguments");
                            if (string.IsNullOrEmpty(customArguments) == false)
                            {
                                pars += " " + customArguments;
                            }

                            myProcess.StartInfo.Arguments = pars + commandLineArguments;
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
                    SetStatus("Missing Unity version: " + version);
                    DisplayUpgradeDialog(version, projectPath);
                }
            }
            else // given path doesnt exists, strange
            {
                SetStatus("Invalid path: " + projectPath);
            }
        }

        bool CheckCrashBackupScene(string projectPath)
        {
            var cancelRunningUnity = false;
            var recoveryFile = Path.Combine(projectPath, "Temp", "__Backupscenes", "0.backup");
            if (File.Exists(recoveryFile))
            {
                DialogResult dialogResult = MessageBox.Show("Crash recovery scene found, do you want to copy it into Assets/_Recovery/-folder?", "UnityLauncher - Scene Recovery", MessageBoxButtons.YesNoCancel);
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
                else if (dialogResult == DialogResult.Cancel) // dont do restore, but run Unity
                {
                    cancelRunningUnity = true;
                }
            }
            return cancelRunningUnity;
        }

        // parse Unity installer exe from release page
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
                    SetStatus("Cannot find UnityDownloadAssistant.exe for this version.");
                }
            }
            return url;
        }

        /// <summary>
        /// launches browser to download installer
        /// </summary>
        /// <param name="url">full url to installer</param>
        void DownloadInBrowser(string url)
        {
            string exeURL = GetDownloadUrlForUnityVersion(url);
            if (string.IsNullOrEmpty(exeURL) == false)
            {
                SetStatus("Download installer in browser: " + exeURL);
                Process.Start(exeURL);
            }
            else // not found
            {
                SetStatus("Error> Cannot find installer executable ... opening website instead");
                Process.Start(url + "#installer-exe-not-found");
            }
        }

        /// <summary>
        /// get rootfolder from settings, default is c:\program files\
        /// </summary>
        /// <returns></returns>
        string[] GetUnityInstallationsRootFolder()
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
                MessageBox.Show("Rare error while checking Unity installation folder settings: " + e.Message, "UnityLauncher", MessageBoxButtons.OK);

                // this doesnt work?
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Save();
            }
            return rootFolders;
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
            FixSelectedRow();
            var selected = gridRecent?.CurrentCell?.RowIndex;

            if (selected.HasValue && selected > -1)
            {
                var projectPath = gridRecent.Rows[(int)selected].Cells["_path"].Value.ToString();
                var version = Tools.GetProjectVersion(projectPath);
                LaunchProject(projectPath, version, openProject);
                SetStatus("Ready");
            }
        }



        void LaunchSelectedUnity()
        {
            
            var selected = gridUnityList?.CurrentCell?.RowIndex;
            if (selected.HasValue && selected > -1)
            {
                SetStatus("Launching Unity..");
                var version = gridUnityList.Rows[(int)selected].Cells["_unityVersion"].Value.ToString();
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


        #region Buttons and UI events

        private void btnRemoveRegister_Click(object sender, EventArgs e)
        {
            Tools.RemoveContextMenuRegistry(contextRegRoot);
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
            var selected = gridUnityList?.CurrentCell?.RowIndex;
            if (selected.HasValue && selected > -1)
            {
                var version = gridUnityList.Rows[(int)selected].Cells["_unityVersion"].Value.ToString();
                if (Tools.OpenReleaseNotes(version) == true)
                {
                    SetStatus("Opening release notes for version " + version);
                }
                else
                {
                    SetStatus("Failed opening Release Notes URL for version " + version);
                }
            }
        }

        private void btnLaunchUnity_Click(object sender, EventArgs e)
        {
            LaunchSelectedUnity();
        }

        private void btnExploreUnity_Click(object sender, EventArgs e)
        {
            
            var selected = gridUnityList?.CurrentCell?.RowIndex;
            if (selected.HasValue && selected > -1)
            {
                var unityPath = Path.GetDirectoryName(gridUnityList.Rows[(int)selected].Cells["_unityPath"].Value.ToString());
                if (Tools.LaunchExplorer(unityPath) == false)
                {
                    SetStatus("Error> Directory not found: " + unityPath);
                }
            }
        }

        private void btnAddUnityFolder_Click(object sender, EventArgs e)
        {
            AddUnityInstallationRootFolder();
            ScanUnityInstallations();
            UpdateRecentProjectsList();
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

        private void btnFetchUnityVersions_Click(object sender, EventArgs e)
        {
            FetchListOfUnityUpdates();
        }

        private void unityGridView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return: // launch selected Unity
                    e.SuppressKeyPress = true;
                    LaunchSelectedUnity();
                    break;
                case Keys.F5: // refresh installed Unity versions list
                    ScanUnityInstallations();
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
            // if editing cells, dont focus on search
            if (gridRecent.IsCurrentCellInEditMode == true) return;

            switch ((int)e.KeyChar)
            {
                case 27: // ESCAPE - clear search
                    if (tabControl1.SelectedIndex == 0 && tbSearchBar.Text != "")
                    {
                        tbSearchBar.Text = "";
                    }
                    else if (tabControl1.SelectedIndex == 3 && tbSearchUpdates.Text != "")
                    {
                        tbSearchUpdates.Text = "";
                    }
                    break;
                default: // any key
                    // activate searchbar if not active and we are in tab#1
                    if (tabControl1.SelectedIndex == 0 && tbSearchBar.Focused == false)
                    {
                        // skip tab key on search field
                        if ((int)e.KeyChar == 9)
                        {
                            break;
                        }
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
            // if editing cells, dont search or launch
            if (gridRecent.IsCurrentCellInEditMode == true) return;

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

        // set basefolder of all Unity installations
        private void btn_setinstallfolder_Click(object sender, EventArgs e)
        {
            AddUnityInstallationRootFolder();
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
            UpdateRecentProjectsList();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            ShowForm();
        }

        private void btn_openFolder_Click(object sender, EventArgs e)
        {
            FixSelectedRow();
            var selected = gridRecent?.CurrentCell?.RowIndex;
            if (selected.HasValue && selected > -1)
            {
                string folder = gridRecent.Rows[(int)selected].Cells["_path"].Value.ToString();
                if (Tools.LaunchExplorer(folder) == false)
                {
                    SetStatus("Error> Directory not found: " + folder);
                }
            }
        }

        private void btnExplorePackageFolder_Click(object sender, EventArgs e)
        {
            var selected = lstPackageFolders.SelectedIndex;
            //Console.WriteLine(lstPackageFolders.Items[selected].ToString());
            if (selected > -1)
            {
                string folder = lstPackageFolders.Items[selected].ToString();
                if (Tools.LaunchExplorer(folder) == false)
                {
                    SetStatus("Error> Directory not found: " + folder);
                }
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
            Tools.AddContextMenuRegistry(contextRegRoot);
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

        private void chkDarkSkin_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.useDarkSkin = chkDarkSkin.Checked;
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
            if (Directory.Exists(logfolder) == true)
            {
                if (Tools.LaunchExplorer(logfolder) == false)
                {
                    SetStatus("Error> Directory not found: " + logfolder);
                }
            }
        }

        private void btnOpenUpdateWebsite_Click(object sender, EventArgs e)
        {
            FixSelectedRow();
            var selected = gridUnityUpdates?.CurrentCell?.RowIndex;
            if (selected.HasValue && selected > -1)
            {
                var version = gridUnityUpdates.Rows[(int)selected].Cells["_UnityUpdateVersion"].Value.ToString();
                Tools.OpenReleaseNotes(version);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if enter Updates tab, then automatically fetch list of Unity versions if list is empty (not fetched)
            if (((TabControl)sender).SelectedIndex == 3) // FIXME: fixed index 3 for this tab..
            {
                if (gridUnityUpdates.Rows.Count == 0)
                {
                    FetchListOfUnityUpdates();
                }
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            var form = (Form)sender;
            Properties.Settings.Default.formWidth = form.Size.Width;
            Properties.Settings.Default.formHeight = form.Size.Height;
            Properties.Settings.Default.Save();
        }

        private void checkShowLauncherArgumentsColumn_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.showArgumentsColumn = chkShowLauncherArgumentsColumn.Checked;
            Properties.Settings.Default.Save();
            gridRecent.Columns["_launchArguments"].Visible = chkShowLauncherArgumentsColumn.Checked;
            // reload list data, if enabled (otherwise missing data)
            if (chkShowLauncherArgumentsColumn.Checked == true) UpdateRecentProjectsList();
        }

        private void checkShowGitBranchColumn_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.showGitBranchColumn = chkShowGitBranchColumn.Checked;
            Properties.Settings.Default.Save();
            gridRecent.Columns["_gitBranch"].Visible = chkShowGitBranchColumn.Checked;
            // reload list data, if enabled (otherwise missing data)
            if (chkShowGitBranchColumn.Checked == true) UpdateRecentProjectsList();
        }


        private void linkArgumentsDocs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.OpenURL("https://docs.unity3d.com/Manual/CommandLineArguments.html");
        }

        private void linkProjectGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.OpenURL("https://github.com/unitycoder/UnityLauncher/releases");
        }


        // after editing launch arguments cell
        private void gridRecent_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string path = GetSelectedRowData("_path");
            if (string.IsNullOrEmpty(path)) return;

            string arguments = GetSelectedRowData("_launchArguments");

            // check folder first
            string outputFolder = Path.Combine(path, "ProjectSettings");
            if (Directory.Exists(outputFolder) == false)
            {
                Directory.CreateDirectory(outputFolder);
            }

            // save arguments to projectsettings folder
            string outputFile = Path.Combine(path, "ProjectSettings", launcherArgumentsFile);

            try
            {
                StreamWriter sw = new StreamWriter(outputFile);
                sw.WriteLine(arguments);
                sw.Close();
            }
            catch (Exception exception)
            {
                SetStatus("File error: " + exception.Message);
            }

            // select the same row again (dont move to next), doesnt work here
            //            var previousRow = gridRecent.CurrentCell.RowIndex;
            //            gridRecent.Rows[previousRow].Selected = true;
        }

        private void btnCheckUpdates_Click(object sender, EventArgs e)
        {
            CheckUpdates();
        }

        private void btnRefreshProjectList_Click(object sender, EventArgs e)
        {
            UpdateRecentProjectsList();
        }

        private void btnBrowseForProject_Click(object sender, EventArgs e)
        {
            BrowseForExistingProjectFolder();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettingsOnExit();
        }

        #endregion UI events




        // displays version selector to upgrade project
        void UpgradeProject()
        {
            FixSelectedRow();
            var selected = gridRecent?.CurrentCell?.RowIndex;
            if (selected.HasValue && selected > -1)
            {
                SetStatus("Upgrading project ...");

                var projectPath = gridRecent.Rows[(int)selected].Cells["_path"].Value.ToString();
                var currentVersion = Tools.GetProjectVersion(projectPath);

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
                    Tools.OpenReleaseNotes(currentVersion);
                    // display window again for now..
                    DisplayUpgradeDialog(currentVersion, projectPath, launchProject);
                    break;
                case DialogResult.Cancel: // cancelled
                    SetStatus("Cancelled project upgrade");
                    break;
                case DialogResult.Retry: // download and install missing version
                    SetStatus("Download and install missing version " + currentVersion);
                    string url = Tools.GetUnityReleaseURL(currentVersion);
                    if (string.IsNullOrEmpty(url) == false)
                    {
                        DownloadInBrowser(url);
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

        private void FetchListOfUnityUpdates()
        {
            if (isDownloadingUnityList == true)
            {
                SetStatus("We are already downloading ...");
                return;
            }
            isDownloadingUnityList = true;
            SetStatus("Downloading list of Unity versions ...");

            // download list of Unity versions
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(UnityVersionsListDownloaded);
                var unityVersionsURL = @"http://symbolserver.unity3d.com/000Admin/history.txt";
                webClient.DownloadStringAsync(new Uri(unityVersionsURL));
            }
        }

        private void UnityVersionsListDownloaded(object sender, DownloadStringCompletedEventArgs e)
        {
            // TODO check for error..
            SetStatus("Downloading list of Unity versions ... done");
            isDownloadingUnityList = false;

            // parse to list
            var receivedList = e.Result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Array.Reverse(receivedList);
            gridUnityUpdates.Rows.Clear();
            // fill in, TODO: show only top 50 or so
            for (int i = 0, len = receivedList.Length; i < len; i++)
            {
                var row = receivedList[i].Split(',');
                var versionTemp = row[6].Trim('"');
                gridUnityUpdates.Rows.Add(row[3], versionTemp);

                // set color if we already have it installed
                gridUnityUpdates.Rows[i].Cells[1].Style.ForeColor = unityList.ContainsKey(versionTemp) ? Color.Green : Color.Black;
            }
        }

        // returns currently selected rows path string
        string GetSelectedRowData(string key)
        {
            string path = null;
            FixSelectedRow();
            var selected = gridRecent?.CurrentCell?.RowIndex;
            if (selected.HasValue && selected > -1)
            {
                path = gridRecent.Rows[(int)selected].Cells[key].Value?.ToString();
            }
            return path;
        }

        void CheckUpdates()
        {
            var result = Tools.CheckUpdates(githubReleaseAPICheckURL, previousGitRelease);
            if (string.IsNullOrEmpty(result) == false)
            {
                SetStatus("Update available: " + result + " - Previous release was:" + previousGitRelease);
                DialogResult dialogResult = MessageBox.Show("Update " + result + " is available, open download page?", "UnityLauncher - Check Update", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) // open download page
                {
                    Tools.OpenURL(githubReleasesLinkURL);
                }
            }
            else
            {
                SetStatus("No updates available. Current release is " + (float.Parse(previousGitRelease) + 0.01f));
            }
        }



        void BrowseForExistingProjectFolder()
        {
            folderBrowserDialog1.Description = "Select existing project folder";
            var d = folderBrowserDialog1.ShowDialog();
            var projectPath = folderBrowserDialog1.SelectedPath;
            if (String.IsNullOrWhiteSpace(projectPath) == false && Directory.Exists(projectPath) == true)
            {

                // TODO: remove duplicate code (from UpdateRecentList())

                string projectName = "";

                Console.WriteLine(Path.DirectorySeparatorChar);
                Console.WriteLine(Path.AltDirectorySeparatorChar);

                // get project name from full path
                if (projectPath.IndexOf(Path.DirectorySeparatorChar) > -1)
                {
                    projectName = projectPath.Substring(projectPath.LastIndexOf(Path.DirectorySeparatorChar) + 1);
                    Console.WriteLine("1");
                }
                else if (projectPath.IndexOf(Path.AltDirectorySeparatorChar) > -1)
                {
                    projectName = projectPath.Substring(projectPath.LastIndexOf(Path.AltDirectorySeparatorChar) + 1);
                    Console.WriteLine("2");
                }
                else // no path separator found
                {
                    projectName = projectPath;
                    Console.WriteLine("3");
                }

                string csprojFile = Path.Combine(projectPath, projectName + ".csproj");

                // editor only project
                if (File.Exists(csprojFile) == false)
                {
                    csprojFile = Path.Combine(projectPath, projectName + ".Editor.csproj");
                }

                // maybe 4.x project
                if (File.Exists(csprojFile) == false)
                {
                    csprojFile = Path.Combine(projectPath, "Assembly-CSharp.csproj");
                }

                // get last modified date
                DateTime? lastUpdated = Tools.GetLastModifiedTime(csprojFile);

                // get project version
                string projectVersion = Tools.GetProjectVersion(projectPath);

                // get custom launch arguments, only if column in enabled
                string customArgs = "";
                if (chkShowLauncherArgumentsColumn.Checked == true)
                {
                    customArgs = Tools.ReadCustomLaunchArguments(projectPath, launcherArgumentsFile);
                }

                // get git branchinfo, only if column in enabled
                string gitBranch = "";
                if (chkShowGitBranchColumn.Checked == true)
                {
                    gitBranch = Tools.ReadGitBranchInfo(projectPath);
                }

                // NOTE: list item will disappear if you dont open the project once..

                // TODO: dont add if not a project??

                gridRecent.Rows.Insert(0, projectName, projectVersion, projectPath, lastUpdated, customArgs, gitBranch);
                gridRecent.Rows[0].Cells[1].Style.ForeColor = HaveExactVersionInstalled(projectVersion) ? Color.Green : Color.Red;
                gridRecent.Rows[0].Selected = true;
                gridRecent.CurrentCell = gridRecent[0, 0]; // reset position to first item
            }
        }

        private void SaveSettingsOnExit()
        {
            // save list column widths
            List<int> gridWidths;
            if (Properties.Settings.Default.gridColumnWidths != null)
            {
                gridWidths = new List<int>(Properties.Settings.Default.gridColumnWidths);
            }
            else
            {
                gridWidths = new List<int>();
            }

            // restore data grid view widths
            var colum = gridRecent.Columns[0];
            for (int i = 0; i < gridRecent.Columns.Count; ++i)
            {
                if (Properties.Settings.Default.gridColumnWidths != null && Properties.Settings.Default.gridColumnWidths.Length > i)
                {
                    gridWidths[i] = gridRecent.Columns[i].Width;
                }
                else
                {
                    gridWidths.Add(gridRecent.Columns[i].Width);
                }
            }
            Properties.Settings.Default.gridColumnWidths = gridWidths.ToArray();
            Properties.Settings.Default.Save();
        }

        void FixSelectedRow()
        {
            if (gridRecent.CurrentCell == null)
            {
                if (gridRecent.SelectedRows.Count != 0)
                {
                    DataGridViewRow row = gridRecent.SelectedRows[0];
                    gridRecent.CurrentCell = row.Cells[0];
                }
            }
        }

    } // class Form 
} // namespace