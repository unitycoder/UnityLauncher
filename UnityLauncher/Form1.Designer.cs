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
            this.tabProjects = new System.Windows.Forms.TabPage();
            this.tbSearchBar = new System.Windows.Forms.TextBox();
            this.btnUpgradeProject = new System.Windows.Forms.Button();
            this.btnRunUnityOnly = new System.Windows.Forms.Button();
            this.btnOpenUnityFolder = new System.Windows.Forms.Button();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.gridRecent = new System.Windows.Forms.DataGridView();
            this._project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dateModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._launchArguments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._gitBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabUnitys = new System.Windows.Forms.TabPage();
            this.btn_refreshUnityList = new System.Windows.Forms.Button();
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
            this.tabUpdates = new System.Windows.Forms.TabPage();
            this.btnOpenUpdateWebsite = new System.Windows.Forms.Button();
            this.btnFetchUnityVersions = new System.Windows.Forms.Button();
            this.gridUnityUpdates = new System.Windows.Forms.DataGridView();
            this._Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._UnityUpdateVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.ChkQuitAfterOpen = new System.Windows.Forms.CheckBox();
            this.btnOpenLogFolder = new System.Windows.Forms.Button();
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
            this.chkShowLauncherArgumentsColumn = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkShowGitBranchColumn = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabProjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecent)).BeginInit();
            this.tabUnitys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUnityList)).BeginInit();
            this.tabPackages.SuspendLayout();
            this.tabUpdates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUnityUpdates)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabProjects);
            this.tabControl1.Controls.Add(this.tabUnitys);
            this.tabControl1.Controls.Add(this.tabPackages);
            this.tabControl1.Controls.Add(this.tabUpdates);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Location = new System.Drawing.Point(0, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(588, 575);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabProjects
            // 
            this.tabProjects.Controls.Add(this.tbSearchBar);
            this.tabProjects.Controls.Add(this.btnUpgradeProject);
            this.tabProjects.Controls.Add(this.btnRunUnityOnly);
            this.tabProjects.Controls.Add(this.btnOpenUnityFolder);
            this.tabProjects.Controls.Add(this.btnLaunch);
            this.tabProjects.Controls.Add(this.gridRecent);
            this.tabProjects.Location = new System.Drawing.Point(4, 22);
            this.tabProjects.Name = "tabProjects";
            this.tabProjects.Size = new System.Drawing.Size(580, 549);
            this.tabProjects.TabIndex = 0;
            this.tabProjects.Text = "Projects";
            this.tabProjects.UseVisualStyleBackColor = true;
            // 
            // tbSearchBar
            // 
            this.tbSearchBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearchBar.Location = new System.Drawing.Point(9, 4);
            this.tbSearchBar.Name = "tbSearchBar";
            this.tbSearchBar.Size = new System.Drawing.Size(563, 20);
            this.tbSearchBar.TabIndex = 0;
            this.tbSearchBar.TextChanged += new System.EventHandler(this.FilterRecentProject);
            // 
            // btnUpgradeProject
            // 
            this.btnUpgradeProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpgradeProject.Location = new System.Drawing.Point(3, 511);
            this.btnUpgradeProject.Name = "btnUpgradeProject";
            this.btnUpgradeProject.Size = new System.Drawing.Size(98, 35);
            this.btnUpgradeProject.TabIndex = 4;
            this.btnUpgradeProject.Text = "Upgrade Project";
            this.toolTip1.SetToolTip(this.btnUpgradeProject, "Open File Explorer");
            this.btnUpgradeProject.UseVisualStyleBackColor = true;
            this.btnUpgradeProject.Click += new System.EventHandler(this.btnUpgradeProject_Click);
            // 
            // btnRunUnityOnly
            // 
            this.btnRunUnityOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRunUnityOnly.Location = new System.Drawing.Point(105, 511);
            this.btnRunUnityOnly.Name = "btnRunUnityOnly";
            this.btnRunUnityOnly.Size = new System.Drawing.Size(67, 35);
            this.btnRunUnityOnly.TabIndex = 5;
            this.btnRunUnityOnly.Text = "Run Unity";
            this.toolTip1.SetToolTip(this.btnRunUnityOnly, "Open File Explorer");
            this.btnRunUnityOnly.UseVisualStyleBackColor = true;
            this.btnRunUnityOnly.Click += new System.EventHandler(this.btnRunUnityOnly_Click);
            // 
            // btnOpenUnityFolder
            // 
            this.btnOpenUnityFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenUnityFolder.Location = new System.Drawing.Point(510, 511);
            this.btnOpenUnityFolder.Name = "btnOpenUnityFolder";
            this.btnOpenUnityFolder.Size = new System.Drawing.Size(67, 35);
            this.btnOpenUnityFolder.TabIndex = 3;
            this.btnOpenUnityFolder.Text = "Explore";
            this.toolTip1.SetToolTip(this.btnOpenUnityFolder, "Open File Explorer");
            this.btnOpenUnityFolder.UseVisualStyleBackColor = true;
            this.btnOpenUnityFolder.Click += new System.EventHandler(this.btn_openFolder_Click);
            // 
            // btnLaunch
            // 
            this.btnLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch.Location = new System.Drawing.Point(176, 511);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(330, 35);
            this.btnLaunch.TabIndex = 2;
            this.btnLaunch.Text = "Launch Project";
            this.toolTip1.SetToolTip(this.btnLaunch, "Launch selected project");
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // gridRecent
            // 
            this.gridRecent.AllowUserToAddRows = false;
            this.gridRecent.AllowUserToDeleteRows = false;
            this.gridRecent.AllowUserToResizeRows = false;
            this.gridRecent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridRecent.CausesValidation = false;
            this.gridRecent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRecent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._project,
            this._version,
            this._path,
            this._dateModified,
            this._launchArguments,
            this._gitBranch});
            this.gridRecent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.gridRecent.Location = new System.Drawing.Point(3, 30);
            this.gridRecent.MultiSelect = false;
            this.gridRecent.Name = "gridRecent";
            this.gridRecent.RowHeadersWidth = 18;
            this.gridRecent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridRecent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRecent.ShowCellErrors = false;
            this.gridRecent.ShowCellToolTips = false;
            this.gridRecent.Size = new System.Drawing.Size(574, 475);
            this.gridRecent.StandardTab = true;
            this.gridRecent.TabIndex = 1;
            this.gridRecent.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRecent_CellEndEdit);
            this.gridRecent.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridRecent_CellMouseDoubleClick);
            this.gridRecent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridRecent_KeyDown);
            // 
            // _project
            // 
            this._project.HeaderText = "Project";
            this._project.Name = "_project";
            this._project.ReadOnly = true;
            this._project.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this._path.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._path.Width = 185;
            // 
            // _dateModified
            // 
            this._dateModified.HeaderText = "Modified";
            this._dateModified.Name = "_dateModified";
            this._dateModified.ReadOnly = true;
            this._dateModified.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._dateModified.Width = 120;
            // 
            // _launchArguments
            // 
            this._launchArguments.HeaderText = "Arguments";
            this._launchArguments.Name = "_launchArguments";
            // 
            // _gitBranch
            // 
            this._gitBranch.HeaderText = "GITBranch";
            this._gitBranch.Name = "_gitBranch";
            this._gitBranch.ReadOnly = true;
            // 
            // tabUnitys
            // 
            this.tabUnitys.Controls.Add(this.btn_refreshUnityList);
            this.tabUnitys.Controls.Add(this.btnOpenReleasePage);
            this.tabUnitys.Controls.Add(this.btnExploreUnity);
            this.tabUnitys.Controls.Add(this.btnLaunchUnity);
            this.tabUnitys.Controls.Add(this.gridUnityList);
            this.tabUnitys.Location = new System.Drawing.Point(4, 22);
            this.tabUnitys.Name = "tabUnitys";
            this.tabUnitys.Size = new System.Drawing.Size(580, 549);
            this.tabUnitys.TabIndex = 1;
            this.tabUnitys.Text = "Unity\'s";
            this.tabUnitys.UseVisualStyleBackColor = true;
            // 
            // btn_refreshUnityList
            // 
            this.btn_refreshUnityList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refreshUnityList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refreshUnityList.Location = new System.Drawing.Point(555, 3);
            this.btn_refreshUnityList.Name = "btn_refreshUnityList";
            this.btn_refreshUnityList.Size = new System.Drawing.Size(22, 23);
            this.btn_refreshUnityList.TabIndex = 21;
            this.btn_refreshUnityList.Text = "⟳";
            this.toolTip1.SetToolTip(this.btn_refreshUnityList, "Refresh Unity Installations List");
            this.btn_refreshUnityList.UseCompatibleTextRendering = true;
            this.btn_refreshUnityList.UseVisualStyleBackColor = true;
            this.btn_refreshUnityList.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOpenReleasePage
            // 
            this.btnOpenReleasePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.btnExploreUnity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.btnLaunchUnity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.gridUnityList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUnityList.CausesValidation = false;
            this.gridUnityList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUnityList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._unityVersion,
            this._unityPath});
            this.gridUnityList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridUnityList.Location = new System.Drawing.Point(3, 27);
            this.gridUnityList.MultiSelect = false;
            this.gridUnityList.Name = "gridUnityList";
            this.gridUnityList.ReadOnly = true;
            this.gridUnityList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridUnityList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUnityList.ShowCellErrors = false;
            this.gridUnityList.ShowCellToolTips = false;
            this.gridUnityList.ShowEditingIcon = false;
            this.gridUnityList.Size = new System.Drawing.Size(574, 478);
            this.gridUnityList.StandardTab = true;
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
            this.btnAddAssetStoreFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnExplorePackageFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.lstPackageFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPackageFolders.FormattingEnabled = true;
            this.lstPackageFolders.Location = new System.Drawing.Point(19, 40);
            this.lstPackageFolders.Name = "lstPackageFolders";
            this.lstPackageFolders.Size = new System.Drawing.Size(539, 186);
            this.lstPackageFolders.TabIndex = 21;
            // 
            // tabUpdates
            // 
            this.tabUpdates.Controls.Add(this.btnOpenUpdateWebsite);
            this.tabUpdates.Controls.Add(this.btnFetchUnityVersions);
            this.tabUpdates.Controls.Add(this.gridUnityUpdates);
            this.tabUpdates.Location = new System.Drawing.Point(4, 22);
            this.tabUpdates.Name = "tabUpdates";
            this.tabUpdates.Size = new System.Drawing.Size(580, 549);
            this.tabUpdates.TabIndex = 5;
            this.tabUpdates.Text = "Updates";
            this.tabUpdates.UseVisualStyleBackColor = true;
            // 
            // btnOpenUpdateWebsite
            // 
            this.btnOpenUpdateWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenUpdateWebsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenUpdateWebsite.Location = new System.Drawing.Point(5, 511);
            this.btnOpenUpdateWebsite.Name = "btnOpenUpdateWebsite";
            this.btnOpenUpdateWebsite.Size = new System.Drawing.Size(572, 35);
            this.btnOpenUpdateWebsite.TabIndex = 24;
            this.btnOpenUpdateWebsite.Text = "Open Website";
            this.toolTip1.SetToolTip(this.btnOpenUpdateWebsite, "Launch selected project");
            this.btnOpenUpdateWebsite.UseVisualStyleBackColor = true;
            this.btnOpenUpdateWebsite.Click += new System.EventHandler(this.btnOpenUpdateWebsite_Click);
            // 
            // btnFetchUnityVersions
            // 
            this.btnFetchUnityVersions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFetchUnityVersions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFetchUnityVersions.Location = new System.Drawing.Point(555, 3);
            this.btnFetchUnityVersions.Name = "btnFetchUnityVersions";
            this.btnFetchUnityVersions.Size = new System.Drawing.Size(22, 23);
            this.btnFetchUnityVersions.TabIndex = 23;
            this.btnFetchUnityVersions.Text = "⟳";
            this.toolTip1.SetToolTip(this.btnFetchUnityVersions, "Fetch list of Unity Updates");
            this.btnFetchUnityVersions.UseCompatibleTextRendering = true;
            this.btnFetchUnityVersions.UseVisualStyleBackColor = true;
            this.btnFetchUnityVersions.Click += new System.EventHandler(this.btnFetchUnityVersions_Click);
            // 
            // gridUnityUpdates
            // 
            this.gridUnityUpdates.AllowUserToAddRows = false;
            this.gridUnityUpdates.AllowUserToDeleteRows = false;
            this.gridUnityUpdates.AllowUserToResizeColumns = false;
            this.gridUnityUpdates.AllowUserToResizeRows = false;
            this.gridUnityUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUnityUpdates.CausesValidation = false;
            this.gridUnityUpdates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUnityUpdates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Date,
            this._UnityUpdateVersion});
            this.gridUnityUpdates.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridUnityUpdates.Location = new System.Drawing.Point(3, 27);
            this.gridUnityUpdates.MultiSelect = false;
            this.gridUnityUpdates.Name = "gridUnityUpdates";
            this.gridUnityUpdates.ReadOnly = true;
            this.gridUnityUpdates.RowHeadersWidth = 18;
            this.gridUnityUpdates.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridUnityUpdates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUnityUpdates.ShowCellErrors = false;
            this.gridUnityUpdates.ShowCellToolTips = false;
            this.gridUnityUpdates.ShowEditingIcon = false;
            this.gridUnityUpdates.Size = new System.Drawing.Size(574, 478);
            this.gridUnityUpdates.StandardTab = true;
            this.gridUnityUpdates.TabIndex = 22;
            // 
            // _Date
            // 
            this._Date.HeaderText = "Date";
            this._Date.MinimumWidth = 100;
            this._Date.Name = "_Date";
            this._Date.ReadOnly = true;
            this._Date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // _UnityUpdateVersion
            // 
            this._UnityUpdateVersion.HeaderText = "Version";
            this._UnityUpdateVersion.MinimumWidth = 350;
            this._UnityUpdateVersion.Name = "_UnityUpdateVersion";
            this._UnityUpdateVersion.ReadOnly = true;
            this._UnityUpdateVersion.Width = 350;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.chkShowGitBranchColumn);
            this.tabSettings.Controls.Add(this.label5);
            this.tabSettings.Controls.Add(this.chkShowLauncherArgumentsColumn);
            this.tabSettings.Controls.Add(this.ChkQuitAfterOpen);
            this.tabSettings.Controls.Add(this.btnOpenLogFolder);
            this.tabSettings.Controls.Add(this.chkQuitAfterCommandline);
            this.tabSettings.Controls.Add(this.btnAddRegister);
            this.tabSettings.Controls.Add(this.btnRemoveRegister);
            this.tabSettings.Controls.Add(this.label4);
            this.tabSettings.Controls.Add(this.label2);
            this.tabSettings.Controls.Add(this.chkMinimizeToTaskbar);
            this.tabSettings.Controls.Add(this.label1);
            this.tabSettings.Controls.Add(this.btnAddUnityFolder);
            this.tabSettings.Controls.Add(this.btnRemoveInstallFolder);
            this.tabSettings.Controls.Add(this.lstRootFolders);
            this.tabSettings.Controls.Add(this.lbl_unityCount);
            this.tabSettings.Controls.Add(this.btnRefresh);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(580, 549);
            this.tabSettings.TabIndex = 3;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // ChkQuitAfterOpen
            // 
            this.ChkQuitAfterOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkQuitAfterOpen.AutoSize = true;
            this.ChkQuitAfterOpen.Location = new System.Drawing.Point(20, 409);
            this.ChkQuitAfterOpen.Name = "ChkQuitAfterOpen";
            this.ChkQuitAfterOpen.Size = new System.Drawing.Size(172, 17);
            this.ChkQuitAfterOpen.TabIndex = 33;
            this.ChkQuitAfterOpen.Text = "Close after launching  a project";
            this.ChkQuitAfterOpen.UseVisualStyleBackColor = true;
            this.ChkQuitAfterOpen.CheckedChanged += new System.EventHandler(this.ChkQuitAfterOpen_CheckedChanged);
            // 
            // btnOpenLogFolder
            // 
            this.btnOpenLogFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenLogFolder.Location = new System.Drawing.Point(432, 512);
            this.btnOpenLogFolder.Name = "btnOpenLogFolder";
            this.btnOpenLogFolder.Size = new System.Drawing.Size(137, 23);
            this.btnOpenLogFolder.TabIndex = 32;
            this.btnOpenLogFolder.Text = "Open Editor Log Folder";
            this.btnOpenLogFolder.UseVisualStyleBackColor = true;
            this.btnOpenLogFolder.Click += new System.EventHandler(this.btnOpenLogFolder_Click);
            // 
            // chkQuitAfterCommandline
            // 
            this.chkQuitAfterCommandline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkQuitAfterCommandline.AutoSize = true;
            this.chkQuitAfterCommandline.Location = new System.Drawing.Point(20, 432);
            this.chkQuitAfterCommandline.Name = "chkQuitAfterCommandline";
            this.chkQuitAfterCommandline.Size = new System.Drawing.Size(189, 17);
            this.chkQuitAfterCommandline.TabIndex = 31;
            this.chkQuitAfterCommandline.Text = "Close after launching from Explorer";
            this.chkQuitAfterCommandline.UseVisualStyleBackColor = true;
            this.chkQuitAfterCommandline.CheckedChanged += new System.EventHandler(this.chkQuitAfterCommandline_CheckedChanged);
            // 
            // btnAddRegister
            // 
            this.btnAddRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddRegister.Location = new System.Drawing.Point(139, 512);
            this.btnAddRegister.Name = "btnAddRegister";
            this.btnAddRegister.Size = new System.Drawing.Size(64, 23);
            this.btnAddRegister.TabIndex = 30;
            this.btnAddRegister.Text = "Install";
            this.btnAddRegister.UseVisualStyleBackColor = true;
            this.btnAddRegister.Click += new System.EventHandler(this.btnAddRegister_Click);
            // 
            // btnRemoveRegister
            // 
            this.btnRemoveRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveRegister.Location = new System.Drawing.Point(209, 512);
            this.btnRemoveRegister.Name = "btnRemoveRegister";
            this.btnRemoveRegister.Size = new System.Drawing.Size(64, 23);
            this.btnRemoveRegister.TabIndex = 29;
            this.btnRemoveRegister.Text = "uninstall";
            this.btnRemoveRegister.UseVisualStyleBackColor = true;
            this.btnRemoveRegister.Click += new System.EventHandler(this.btnRemoveRegister_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 517);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Explorer Context Menu:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Other Settings";
            // 
            // chkMinimizeToTaskbar
            // 
            this.chkMinimizeToTaskbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.lstRootFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRootFolders.FormattingEnabled = true;
            this.lstRootFolders.Location = new System.Drawing.Point(20, 31);
            this.lstRootFolders.Name = "lstRootFolders";
            this.lstRootFolders.Size = new System.Drawing.Size(552, 186);
            this.lstRootFolders.TabIndex = 20;
            // 
            // lbl_unityCount
            // 
            this.lbl_unityCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_unityCount.AutoSize = true;
            this.lbl_unityCount.Enabled = false;
            this.lbl_unityCount.Location = new System.Drawing.Point(472, 15);
            this.lbl_unityCount.Name = "lbl_unityCount";
            this.lbl_unityCount.Size = new System.Drawing.Size(97, 13);
            this.lbl_unityCount.TabIndex = 18;
            this.lbl_unityCount.Text = "Founded - versions";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(135, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // chkShowLauncherArgumentsColumn
            // 
            this.chkShowLauncherArgumentsColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowLauncherArgumentsColumn.AutoSize = true;
            this.chkShowLauncherArgumentsColumn.Location = new System.Drawing.Point(266, 386);
            this.chkShowLauncherArgumentsColumn.Name = "chkShowLauncherArgumentsColumn";
            this.chkShowLauncherArgumentsColumn.Size = new System.Drawing.Size(124, 17);
            this.chkShowLauncherArgumentsColumn.TabIndex = 34;
            this.chkShowLauncherArgumentsColumn.Text = "Launcher Arguments";
            this.chkShowLauncherArgumentsColumn.UseVisualStyleBackColor = true;
            this.chkShowLauncherArgumentsColumn.CheckedChanged += new System.EventHandler(this.checkShowLauncherArgumentsColumn_CheckedChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(263, 361);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Optional Columns";
            // 
            // chkShowGitBranchColumn
            // 
            this.chkShowGitBranchColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowGitBranchColumn.AutoSize = true;
            this.chkShowGitBranchColumn.Location = new System.Drawing.Point(266, 409);
            this.chkShowGitBranchColumn.Name = "chkShowGitBranchColumn";
            this.chkShowGitBranchColumn.Size = new System.Drawing.Size(76, 17);
            this.chkShowGitBranchColumn.TabIndex = 36;
            this.chkShowGitBranchColumn.Text = "Git Branch";
            this.chkShowGitBranchColumn.UseVisualStyleBackColor = true;
            this.chkShowGitBranchColumn.CheckedChanged += new System.EventHandler(this.checkShowGitBranchColumn_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 612);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 650);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "UnityLauncher - Hub Edition 18";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabProjects.ResumeLayout(false);
            this.tabProjects.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecent)).EndInit();
            this.tabUnitys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUnityList)).EndInit();
            this.tabPackages.ResumeLayout(false);
            this.tabPackages.PerformLayout();
            this.tabUpdates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUnityUpdates)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProjects;
        private System.Windows.Forms.Button btnOpenUnityFolder;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.DataGridView gridRecent;
        private System.Windows.Forms.TabPage tabUnitys;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TabPage tabSettings;
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
        private System.Windows.Forms.Button btnOpenLogFolder;
        private System.Windows.Forms.TextBox tbSearchBar;
        private System.Windows.Forms.CheckBox ChkQuitAfterOpen;
        private System.Windows.Forms.Button btn_refreshUnityList;
        private System.Windows.Forms.TabPage tabUpdates;
        private System.Windows.Forms.Button btnFetchUnityVersions;
        private System.Windows.Forms.DataGridView gridUnityUpdates;
        private System.Windows.Forms.Button btnOpenUpdateWebsite;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn _UnityUpdateVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn _project;
        private System.Windows.Forms.DataGridViewTextBoxColumn _version;
        private System.Windows.Forms.DataGridViewTextBoxColumn _path;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dateModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn _launchArguments;
        private System.Windows.Forms.DataGridViewTextBoxColumn _gitBranch;
        private System.Windows.Forms.CheckBox chkShowGitBranchColumn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkShowLauncherArgumentsColumn;
    }
}

