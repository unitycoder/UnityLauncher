namespace UnityLauncher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnUpgradeProject = new System.Windows.Forms.Button();
            this.btnRunUnityOnly = new System.Windows.Forms.Button();
            this.btnOpenUnityFolder = new System.Windows.Forms.Button();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.gridRecent = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnOpenReleasePage = new System.Windows.Forms.Button();
            this.btnExploreUnity = new System.Windows.Forms.Button();
            this.btnLaunchUnity = new System.Windows.Forms.Button();
            this.gridUnityList = new System.Windows.Forms.DataGridView();
            this._unityVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._unityPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPackages = new System.Windows.Forms.TabPage();
            this.btnAddAssetStoreFolder = new System.Windows.Forms.Button();
            this.btnExplorePackageFolder = new System.Windows.Forms.Button();
            this.btnAddPackageFolder = new System.Windows.Forms.Button();
            this.btnRemovePackFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstPackageFolders = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkQuitAfterCommandline = new System.Windows.Forms.CheckBox();
            this.btnAddRegister = new System.Windows.Forms.Button();
            this.btnRemoveRegister = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkMinimizeToTaskbar = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddUnityFolder = new System.Windows.Forms.Button();
            this.btnRemoveInstallFolder = new System.Windows.Forms.Button();
            this.lstRootFolders = new System.Windows.Forms.ListBox();
            this.lbl_unityCount = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnAddPackFolder = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this._project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dateModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOpenLogFolder = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecent)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUnityList)).BeginInit();
            this.tabPackages.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPackages);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(588, 575);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnUpgradeProject);
            this.tabPage1.Controls.Add(this.btnRunUnityOnly);
            this.tabPage1.Controls.Add(this.btnOpenUnityFolder);
            this.tabPage1.Controls.Add(this.btnLaunch);
            this.tabPage1.Controls.Add(this.gridRecent);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(580, 549);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Projects";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnUpgradeProject
            // 
            this.btnUpgradeProject.Location = new System.Drawing.Point(3, 511);
            this.btnUpgradeProject.Name = "btnUpgradeProject";
            this.btnUpgradeProject.Size = new System.Drawing.Size(98, 35);
            this.btnUpgradeProject.TabIndex = 16;
            this.btnUpgradeProject.Text = "Upgrade Project";
            this.toolTip1.SetToolTip(this.btnUpgradeProject, "Open File Explorer");
            this.btnUpgradeProject.UseVisualStyleBackColor = true;
            this.btnUpgradeProject.Click += new System.EventHandler(this.btnUpgradeProject_Click);
            // 
            // btnRunUnityOnly
            // 
            this.btnRunUnityOnly.Location = new System.Drawing.Point(105, 511);
            this.btnRunUnityOnly.Name = "btnRunUnityOnly";
            this.btnRunUnityOnly.Size = new System.Drawing.Size(67, 35);
            this.btnRunUnityOnly.TabIndex = 15;
            this.btnRunUnityOnly.Text = "Run Unity";
            this.toolTip1.SetToolTip(this.btnRunUnityOnly, "Open File Explorer");
            this.btnRunUnityOnly.UseVisualStyleBackColor = true;
            this.btnRunUnityOnly.Click += new System.EventHandler(this.btnRunUnityOnly_Click);
            // 
            // btnOpenUnityFolder
            // 
            this.btnOpenUnityFolder.Location = new System.Drawing.Point(510, 511);
            this.btnOpenUnityFolder.Name = "btnOpenUnityFolder";
            this.btnOpenUnityFolder.Size = new System.Drawing.Size(67, 35);
            this.btnOpenUnityFolder.TabIndex = 14;
            this.btnOpenUnityFolder.Text = "Explore";
            this.toolTip1.SetToolTip(this.btnOpenUnityFolder, "Open File Explorer");
            this.btnOpenUnityFolder.UseVisualStyleBackColor = true;
            this.btnOpenUnityFolder.Click += new System.EventHandler(this.btn_openFolder_Click);
            // 
            // btnLaunch
            // 
            this.btnLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch.Location = new System.Drawing.Point(176, 511);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(330, 35);
            this.btnLaunch.TabIndex = 10;
            this.btnLaunch.Text = "Launch Project";
            this.toolTip1.SetToolTip(this.btnLaunch, "Launch selected project");
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // gridRecent
            // 
            this.gridRecent.AllowUserToAddRows = false;
            this.gridRecent.AllowUserToDeleteRows = false;
            this.gridRecent.AllowUserToResizeColumns = false;
            this.gridRecent.AllowUserToResizeRows = false;
            this.gridRecent.CausesValidation = false;
            this.gridRecent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRecent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._project,
            this._version,
            this._path,
            this._dateModified});
            this.gridRecent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridRecent.Location = new System.Drawing.Point(3, 3);
            this.gridRecent.MultiSelect = false;
            this.gridRecent.Name = "gridRecent";
            this.gridRecent.ReadOnly = true;
            this.gridRecent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridRecent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRecent.ShowCellErrors = false;
            this.gridRecent.ShowCellToolTips = false;
            this.gridRecent.ShowEditingIcon = false;
            this.gridRecent.Size = new System.Drawing.Size(574, 502);
            this.gridRecent.TabIndex = 0;
            this.gridRecent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridRecent_KeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnOpenReleasePage);
            this.tabPage2.Controls.Add(this.btnExploreUnity);
            this.tabPage2.Controls.Add(this.btnLaunchUnity);
            this.tabPage2.Controls.Add(this.gridUnityList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(580, 549);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Unity\'s";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnOpenReleasePage
            // 
            this.btnOpenReleasePage.Location = new System.Drawing.Point(411, 511);
            this.btnOpenReleasePage.Name = "btnOpenReleasePage";
            this.btnOpenReleasePage.Size = new System.Drawing.Size(80, 35);
            this.btnOpenReleasePage.TabIndex = 17;
            this.btnOpenReleasePage.Text = "Release Notes";
            this.toolTip1.SetToolTip(this.btnOpenReleasePage, "Open File Explorer");
            this.btnOpenReleasePage.UseVisualStyleBackColor = true;
            this.btnOpenReleasePage.Click += new System.EventHandler(this.btnOpenReleasePage_Click);
            // 
            // btnExploreUnity
            // 
            this.btnExploreUnity.Location = new System.Drawing.Point(497, 511);
            this.btnExploreUnity.Name = "btnExploreUnity";
            this.btnExploreUnity.Size = new System.Drawing.Size(80, 35);
            this.btnExploreUnity.TabIndex = 16;
            this.btnExploreUnity.Text = "Explore";
            this.toolTip1.SetToolTip(this.btnExploreUnity, "Open File Explorer");
            this.btnExploreUnity.UseVisualStyleBackColor = true;
            this.btnExploreUnity.Click += new System.EventHandler(this.btnExploreUnity_Click);
            // 
            // btnLaunchUnity
            // 
            this.btnLaunchUnity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunchUnity.Location = new System.Drawing.Point(3, 511);
            this.btnLaunchUnity.Name = "btnLaunchUnity";
            this.btnLaunchUnity.Size = new System.Drawing.Size(402, 35);
            this.btnLaunchUnity.TabIndex = 15;
            this.btnLaunchUnity.Text = "Run Unity";
            this.toolTip1.SetToolTip(this.btnLaunchUnity, "Launch selected project");
            this.btnLaunchUnity.UseVisualStyleBackColor = true;
            this.btnLaunchUnity.Click += new System.EventHandler(this.btnLaunchUnity_Click);
            // 
            // gridUnityList
            // 
            this.gridUnityList.AllowUserToAddRows = false;
            this.gridUnityList.AllowUserToDeleteRows = false;
            this.gridUnityList.AllowUserToResizeColumns = false;
            this.gridUnityList.AllowUserToResizeRows = false;
            this.gridUnityList.CausesValidation = false;
            this.gridUnityList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUnityList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._unityVersion,
            this._unityPath});
            this.gridUnityList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridUnityList.Location = new System.Drawing.Point(3, 3);
            this.gridUnityList.MultiSelect = false;
            this.gridUnityList.Name = "gridUnityList";
            this.gridUnityList.ReadOnly = true;
            this.gridUnityList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridUnityList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUnityList.ShowCellErrors = false;
            this.gridUnityList.ShowCellToolTips = false;
            this.gridUnityList.ShowEditingIcon = false;
            this.gridUnityList.Size = new System.Drawing.Size(574, 502);
            this.gridUnityList.TabIndex = 10;
            this.gridUnityList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.unityGridView_KeyDown);
            // 
            // _unityVersion
            // 
            this._unityVersion.HeaderText = "Version";
            this._unityVersion.MinimumWidth = 150;
            this._unityVersion.Name = "_unityVersion";
            this._unityVersion.ReadOnly = true;
            this._unityVersion.Width = 150;
            // 
            // _unityPath
            // 
            this._unityPath.HeaderText = "Path";
            this._unityPath.MinimumWidth = 300;
            this._unityPath.Name = "_unityPath";
            this._unityPath.ReadOnly = true;
            this._unityPath.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._unityPath.Width = 300;
            // 
            // tabPackages
            // 
            this.tabPackages.Controls.Add(this.btnAddAssetStoreFolder);
            this.tabPackages.Controls.Add(this.btnExplorePackageFolder);
            this.tabPackages.Controls.Add(this.btnAddPackageFolder);
            this.tabPackages.Controls.Add(this.btnRemovePackFolder);
            this.tabPackages.Controls.Add(this.label3);
            this.tabPackages.Controls.Add(this.lstPackageFolders);
            this.tabPackages.Location = new System.Drawing.Point(4, 22);
            this.tabPackages.Name = "tabPackages";
            this.tabPackages.Size = new System.Drawing.Size(580, 549);
            this.tabPackages.TabIndex = 4;
            this.tabPackages.Text = "My Packages";
            this.tabPackages.UseVisualStyleBackColor = true;
            // 
            // btnAddAssetStoreFolder
            // 
            this.btnAddAssetStoreFolder.Location = new System.Drawing.Point(416, 232);
            this.btnAddAssetStoreFolder.Name = "btnAddAssetStoreFolder";
            this.btnAddAssetStoreFolder.Size = new System.Drawing.Size(142, 23);
            this.btnAddAssetStoreFolder.TabIndex = 29;
            this.btnAddAssetStoreFolder.Text = "Add AssetStore Folder";
            this.btnAddAssetStoreFolder.UseVisualStyleBackColor = true;
            this.btnAddAssetStoreFolder.Click += new System.EventHandler(this.btnAddAssetStoreFolder_Click);
            // 
            // btnExplorePackageFolder
            // 
            this.btnExplorePackageFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExplorePackageFolder.Location = new System.Drawing.Point(3, 511);
            this.btnExplorePackageFolder.Name = "btnExplorePackageFolder";
            this.btnExplorePackageFolder.Size = new System.Drawing.Size(574, 35);
            this.btnExplorePackageFolder.TabIndex = 28;
            this.btnExplorePackageFolder.Text = "Explore";
            this.toolTip1.SetToolTip(this.btnExplorePackageFolder, "Open File Explorer");
            this.btnExplorePackageFolder.UseVisualStyleBackColor = true;
            this.btnExplorePackageFolder.Click += new System.EventHandler(this.btnExplorePackageFolder_Click);
            // 
            // btnAddPackageFolder
            // 
            this.btnAddPackageFolder.Location = new System.Drawing.Point(19, 232);
            this.btnAddPackageFolder.Name = "btnAddPackageFolder";
            this.btnAddPackageFolder.Size = new System.Drawing.Size(75, 23);
            this.btnAddPackageFolder.TabIndex = 27;
            this.btnAddPackageFolder.Text = "Add Folder";
            this.btnAddPackageFolder.UseVisualStyleBackColor = true;
            this.btnAddPackageFolder.Click += new System.EventHandler(this.btnAddPackageFolder_Click);
            // 
            // btnRemovePackFolder
            // 
            this.btnRemovePackFolder.Location = new System.Drawing.Point(100, 232);
            this.btnRemovePackFolder.Name = "btnRemovePackFolder";
            this.btnRemovePackFolder.Size = new System.Drawing.Size(104, 23);
            this.btnRemovePackFolder.TabIndex = 26;
            this.btnRemovePackFolder.Text = "Remove Folder";
            this.btnRemovePackFolder.UseVisualStyleBackColor = true;
            this.btnRemovePackFolder.Click += new System.EventHandler(this.btnRemovePackFolder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(16, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "My Package Folders";
            // 
            // lstPackageFolders
            // 
            this.lstPackageFolders.FormattingEnabled = true;
            this.lstPackageFolders.Location = new System.Drawing.Point(19, 40);
            this.lstPackageFolders.Name = "lstPackageFolders";
            this.lstPackageFolders.Size = new System.Drawing.Size(539, 186);
            this.lstPackageFolders.TabIndex = 21;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnOpenLogFolder);
            this.tabPage3.Controls.Add(this.chkQuitAfterCommandline);
            this.tabPage3.Controls.Add(this.btnAddRegister);
            this.tabPage3.Controls.Add(this.btnRemoveRegister);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.chkMinimizeToTaskbar);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.btnAddUnityFolder);
            this.tabPage3.Controls.Add(this.btnRemoveInstallFolder);
            this.tabPage3.Controls.Add(this.lstRootFolders);
            this.tabPage3.Controls.Add(this.lbl_unityCount);
            this.tabPage3.Controls.Add(this.btnRefresh);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(580, 549);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkQuitAfterCommandline
            // 
            this.chkQuitAfterCommandline.AutoSize = true;
            this.chkQuitAfterCommandline.Location = new System.Drawing.Point(20, 409);
            this.chkQuitAfterCommandline.Name = "chkQuitAfterCommandline";
            this.chkQuitAfterCommandline.Size = new System.Drawing.Size(189, 17);
            this.chkQuitAfterCommandline.TabIndex = 31;
            this.chkQuitAfterCommandline.Text = "Close after launching from Explorer";
            this.chkQuitAfterCommandline.UseVisualStyleBackColor = true;
            this.chkQuitAfterCommandline.CheckedChanged += new System.EventHandler(this.chkQuitAfterCommandline_CheckedChanged);
            // 
            // btnAddRegister
            // 
            this.btnAddRegister.Location = new System.Drawing.Point(139, 442);
            this.btnAddRegister.Name = "btnAddRegister";
            this.btnAddRegister.Size = new System.Drawing.Size(64, 23);
            this.btnAddRegister.TabIndex = 30;
            this.btnAddRegister.Text = "Install";
            this.btnAddRegister.UseVisualStyleBackColor = true;
            this.btnAddRegister.Click += new System.EventHandler(this.btnAddRegister_Click);
            // 
            // btnRemoveRegister
            // 
            this.btnRemoveRegister.Location = new System.Drawing.Point(209, 442);
            this.btnRemoveRegister.Name = "btnRemoveRegister";
            this.btnRemoveRegister.Size = new System.Drawing.Size(64, 23);
            this.btnRemoveRegister.TabIndex = 29;
            this.btnRemoveRegister.Text = "uninstall";
            this.btnRemoveRegister.UseVisualStyleBackColor = true;
            this.btnRemoveRegister.Click += new System.EventHandler(this.btnRemoveRegister_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 447);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Explorer Context Menu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(17, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Other Settings";
            // 
            // chkMinimizeToTaskbar
            // 
            this.chkMinimizeToTaskbar.AutoSize = true;
            this.chkMinimizeToTaskbar.Location = new System.Drawing.Point(20, 386);
            this.chkMinimizeToTaskbar.Name = "chkMinimizeToTaskbar";
            this.chkMinimizeToTaskbar.Size = new System.Drawing.Size(116, 17);
            this.chkMinimizeToTaskbar.TabIndex = 25;
            this.chkMinimizeToTaskbar.Text = "Minimize to taskbar";
            this.chkMinimizeToTaskbar.UseVisualStyleBackColor = true;
            this.chkMinimizeToTaskbar.CheckedChanged += new System.EventHandler(this.chkMinimizeToTaskbar_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Unity Parent Folders";
            // 
            // btnAddUnityFolder
            // 
            this.btnAddUnityFolder.Location = new System.Drawing.Point(20, 223);
            this.btnAddUnityFolder.Name = "btnAddUnityFolder";
            this.btnAddUnityFolder.Size = new System.Drawing.Size(75, 23);
            this.btnAddUnityFolder.TabIndex = 23;
            this.btnAddUnityFolder.Text = "Add Folder";
            this.btnAddUnityFolder.UseVisualStyleBackColor = true;
            this.btnAddUnityFolder.Click += new System.EventHandler(this.btnAddUnityFolder_Click);
            // 
            // btnRemoveInstallFolder
            // 
            this.btnRemoveInstallFolder.Location = new System.Drawing.Point(101, 223);
            this.btnRemoveInstallFolder.Name = "btnRemoveInstallFolder";
            this.btnRemoveInstallFolder.Size = new System.Drawing.Size(104, 23);
            this.btnRemoveInstallFolder.TabIndex = 22;
            this.btnRemoveInstallFolder.Text = "Remove Folder";
            this.btnRemoveInstallFolder.UseVisualStyleBackColor = true;
            this.btnRemoveInstallFolder.Click += new System.EventHandler(this.btnRemoveInstallFolder_Click);
            // 
            // lstRootFolders
            // 
            this.lstRootFolders.FormattingEnabled = true;
            this.lstRootFolders.Location = new System.Drawing.Point(20, 31);
            this.lstRootFolders.Name = "lstRootFolders";
            this.lstRootFolders.Size = new System.Drawing.Size(552, 186);
            this.lstRootFolders.TabIndex = 20;
            // 
            // lbl_unityCount
            // 
            this.lbl_unityCount.AutoSize = true;
            this.lbl_unityCount.Enabled = false;
            this.lbl_unityCount.Location = new System.Drawing.Point(475, 15);
            this.lbl_unityCount.Name = "lbl_unityCount";
            this.lbl_unityCount.Size = new System.Drawing.Size(97, 13);
            this.lbl_unityCount.TabIndex = 18;
            this.lbl_unityCount.Text = "Founded - versions";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(435, 223);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(137, 23);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "Refresh Unity List";
            this.toolTip1.SetToolTip(this.btnRefresh, "Refresh Unity Installations List");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "UnityLauncher";
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "UnityLauncher";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // btnAddPackFolder
            // 
            this.btnAddPackFolder.Location = new System.Drawing.Point(19, 232);
            this.btnAddPackFolder.Name = "btnAddPackFolder";
            this.btnAddPackFolder.Size = new System.Drawing.Size(75, 23);
            this.btnAddPackFolder.TabIndex = 27;
            this.btnAddPackFolder.Text = "Add Folder";
            this.btnAddPackFolder.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(588, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // _project
            // 
            this._project.HeaderText = "Project";
            this._project.Name = "_project";
            this._project.ReadOnly = true;
            this._project.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._project.Width = 150;
            // 
            // _version
            // 
            this._version.HeaderText = "Version";
            this._version.Name = "_version";
            this._version.ReadOnly = true;
            this._version.Width = 72;
            // 
            // _path
            // 
            this._path.HeaderText = "Path";
            this._path.Name = "_path";
            this._path.ReadOnly = true;
            this._path.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._path.Width = 185;
            // 
            // _dateModified
            // 
            this._dateModified.HeaderText = "Modified";
            this._dateModified.Name = "_dateModified";
            this._dateModified.ReadOnly = true;
            this._dateModified.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._dateModified.Width = 120;
            // 
            // btnOpenLogFolder
            // 
            this.btnOpenLogFolder.Location = new System.Drawing.Point(435, 380);
            this.btnOpenLogFolder.Name = "btnOpenLogFolder";
            this.btnOpenLogFolder.Size = new System.Drawing.Size(137, 23);
            this.btnOpenLogFolder.TabIndex = 32;
            this.btnOpenLogFolder.Text = "Open Editor Log Folder";
            this.btnOpenLogFolder.UseVisualStyleBackColor = true;
            this.btnOpenLogFolder.Click += new System.EventHandler(this.btnOpenLogFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 612);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "UnityLauncher - Potato Edition 9";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRecent)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUnityList)).EndInit();
            this.tabPackages.ResumeLayout(false);
            this.tabPackages.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnOpenUnityFolder;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.DataGridView gridRecent;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lbl_unityCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView gridUnityList;
        private System.Windows.Forms.Button btnExploreUnity;
        private System.Windows.Forms.Button btnLaunchUnity;
        private System.Windows.Forms.DataGridViewTextBoxColumn _unityVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn _unityPath;
        private System.Windows.Forms.ListBox lstRootFolders;
        private System.Windows.Forms.Button btnAddUnityFolder;
        private System.Windows.Forms.Button btnRemoveInstallFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenReleasePage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkMinimizeToTaskbar;
        private System.Windows.Forms.TabPage tabPackages;
        private System.Windows.Forms.ListBox lstPackageFolders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExplorePackageFolder;
        private System.Windows.Forms.Button btnAddPackageFolder;
        private System.Windows.Forms.Button btnRemovePackFolder;
        private System.Windows.Forms.Button btnAddPackFolder;
        private System.Windows.Forms.Button btnAddAssetStoreFolder;
        private System.Windows.Forms.Button btnAddRegister;
        private System.Windows.Forms.Button btnRemoveRegister;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkQuitAfterCommandline;
        private System.Windows.Forms.Button btnRunUnityOnly;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnUpgradeProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn _project;
        private System.Windows.Forms.DataGridViewTextBoxColumn _version;
        private System.Windows.Forms.DataGridViewTextBoxColumn _path;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dateModified;
        private System.Windows.Forms.Button btnOpenLogFolder;
    }
}

