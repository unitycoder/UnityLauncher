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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnOpenUnityFolder = new System.Windows.Forms.Button();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.gridRecent = new System.Windows.Forms.DataGridView();
            this._project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dateModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnExploreUnity = new System.Windows.Forms.Button();
            this.btnLaunchUnity = new System.Windows.Forms.Button();
            this.gridUnityList = new System.Windows.Forms.DataGridView();
            this._unityVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._unityPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lstRootFolders = new System.Windows.Forms.ListBox();
            this.lbl_unityCount = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecent)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUnityList)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(544, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(544, 575);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnOpenUnityFolder);
            this.tabPage1.Controls.Add(this.btnLaunch);
            this.tabPage1.Controls.Add(this.gridRecent);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(536, 549);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Projects";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnOpenUnityFolder
            // 
            this.btnOpenUnityFolder.Location = new System.Drawing.Point(453, 511);
            this.btnOpenUnityFolder.Name = "btnOpenUnityFolder";
            this.btnOpenUnityFolder.Size = new System.Drawing.Size(80, 35);
            this.btnOpenUnityFolder.TabIndex = 14;
            this.btnOpenUnityFolder.Text = "Explore";
            this.toolTip1.SetToolTip(this.btnOpenUnityFolder, "Open File Explorer");
            this.btnOpenUnityFolder.UseVisualStyleBackColor = true;
            // 
            // btnLaunch
            // 
            this.btnLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch.Location = new System.Drawing.Point(3, 511);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(444, 35);
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
            this.gridRecent.Size = new System.Drawing.Size(530, 502);
            this.gridRecent.TabIndex = 0;
            this.gridRecent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridRecent_KeyDown);
            // 
            // _project
            // 
            this._project.HeaderText = "Project";
            this._project.Name = "_project";
            this._project.ReadOnly = true;
            this._project.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._project.Width = 135;
            // 
            // _version
            // 
            this._version.HeaderText = "Version";
            this._version.Name = "_version";
            this._version.ReadOnly = true;
            this._version.Width = 65;
            // 
            // _path
            // 
            this._path.HeaderText = "Path";
            this._path.Name = "_path";
            this._path.ReadOnly = true;
            this._path.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._path.Width = 178;
            // 
            // _dateModified
            // 
            this._dateModified.HeaderText = "Modified";
            this._dateModified.Name = "_dateModified";
            this._dateModified.ReadOnly = true;
            this._dateModified.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._dateModified.Width = 77;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnExploreUnity);
            this.tabPage2.Controls.Add(this.btnLaunchUnity);
            this.tabPage2.Controls.Add(this.gridUnityList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(536, 549);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Unity\'s";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnExploreUnity
            // 
            this.btnExploreUnity.Location = new System.Drawing.Point(453, 511);
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
            this.btnLaunchUnity.Size = new System.Drawing.Size(444, 35);
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
            this.gridUnityList.Size = new System.Drawing.Size(530, 502);
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnAddFolder);
            this.tabPage3.Controls.Add(this.btnRemove);
            this.tabPage3.Controls.Add(this.lstRootFolders);
            this.tabPage3.Controls.Add(this.lbl_unityCount);
            this.tabPage3.Controls.Add(this.btnRefresh);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(536, 549);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(20, 223);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(75, 23);
            this.btnAddFolder.TabIndex = 23;
            this.btnAddFolder.Text = "Add Folder";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(101, 223);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 22;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lstRootFolders
            // 
            this.lstRootFolders.FormattingEnabled = true;
            this.lstRootFolders.Location = new System.Drawing.Point(20, 31);
            this.lstRootFolders.Name = "lstRootFolders";
            this.lstRootFolders.Size = new System.Drawing.Size(495, 186);
            this.lstRootFolders.TabIndex = 20;
            // 
            // lbl_unityCount
            // 
            this.lbl_unityCount.AutoSize = true;
            this.lbl_unityCount.Enabled = false;
            this.lbl_unityCount.Location = new System.Drawing.Point(418, 15);
            this.lbl_unityCount.Name = "lbl_unityCount";
            this.lbl_unityCount.Size = new System.Drawing.Size(97, 13);
            this.lbl_unityCount.TabIndex = 18;
            this.lbl_unityCount.Text = "Founded - versions";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(421, 223);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 23);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "Refresh List";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 612);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "UnityLauncher - Potato Edition 3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRecent)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUnityList)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnOpenUnityFolder;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.DataGridView gridRecent;
        private System.Windows.Forms.DataGridViewTextBoxColumn _project;
        private System.Windows.Forms.DataGridViewTextBoxColumn _version;
        private System.Windows.Forms.DataGridViewTextBoxColumn _path;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dateModified;
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
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnRemove;
    }
}

