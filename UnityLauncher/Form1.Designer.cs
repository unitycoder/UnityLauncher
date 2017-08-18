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
            this.btn_openFolder = new System.Windows.Forms.Button();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.gridRecent = new System.Windows.Forms.DataGridView();
            this._project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dateModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.unityGridView = new System.Windows.Forms.DataGridView();
            this._unityVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._unityPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lbl_unityCount = new System.Windows.Forms.Label();
            this.btn_setinstallfolder = new System.Windows.Forms.Button();
            this.txtRootFolder = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecent)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unityGridView)).BeginInit();
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
            this.tabPage1.Controls.Add(this.btn_openFolder);
            this.tabPage1.Controls.Add(this.btnLaunch);
            this.tabPage1.Controls.Add(this.gridRecent);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(536, 549);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Projects";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_openFolder
            // 
            this.btn_openFolder.Location = new System.Drawing.Point(453, 511);
            this.btn_openFolder.Name = "btn_openFolder";
            this.btn_openFolder.Size = new System.Drawing.Size(80, 35);
            this.btn_openFolder.TabIndex = 14;
            this.btn_openFolder.Text = "Explore";
            this.toolTip1.SetToolTip(this.btn_openFolder, "Open File Explorer");
            this.btn_openFolder.UseVisualStyleBackColor = true;
            this.btn_openFolder.Click += new System.EventHandler(this.btn_openFolder_Click);
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
            this.gridRecent.TabIndex = 9;
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
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.unityGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(536, 549);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Unity\'s";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(453, 511);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 35);
            this.button1.TabIndex = 16;
            this.button1.Text = "Explore";
            this.toolTip1.SetToolTip(this.button1, "Open File Explorer");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(3, 511);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(444, 35);
            this.button2.TabIndex = 15;
            this.button2.Text = "Run Unity";
            this.toolTip1.SetToolTip(this.button2, "Launch selected project");
            this.button2.UseVisualStyleBackColor = true;
            // 
            // unityGridView
            // 
            this.unityGridView.AllowUserToAddRows = false;
            this.unityGridView.AllowUserToDeleteRows = false;
            this.unityGridView.AllowUserToResizeColumns = false;
            this.unityGridView.AllowUserToResizeRows = false;
            this.unityGridView.CausesValidation = false;
            this.unityGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.unityGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._unityVersion,
            this._unityPath});
            this.unityGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.unityGridView.Location = new System.Drawing.Point(3, 3);
            this.unityGridView.MultiSelect = false;
            this.unityGridView.Name = "unityGridView";
            this.unityGridView.ReadOnly = true;
            this.unityGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.unityGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.unityGridView.ShowCellErrors = false;
            this.unityGridView.ShowCellToolTips = false;
            this.unityGridView.ShowEditingIcon = false;
            this.unityGridView.Size = new System.Drawing.Size(530, 502);
            this.unityGridView.TabIndex = 10;
            this.unityGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.unityGridView_KeyDown);
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
            this.tabPage3.Controls.Add(this.lbl_unityCount);
            this.tabPage3.Controls.Add(this.btn_setinstallfolder);
            this.tabPage3.Controls.Add(this.txtRootFolder);
            this.tabPage3.Controls.Add(this.btnRefresh);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(536, 549);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lbl_unityCount
            // 
            this.lbl_unityCount.AutoSize = true;
            this.lbl_unityCount.Enabled = false;
            this.lbl_unityCount.Location = new System.Drawing.Point(280, 19);
            this.lbl_unityCount.Name = "lbl_unityCount";
            this.lbl_unityCount.Size = new System.Drawing.Size(97, 13);
            this.lbl_unityCount.TabIndex = 18;
            this.lbl_unityCount.Text = "Founded - versions";
            // 
            // btn_setinstallfolder
            // 
            this.btn_setinstallfolder.Location = new System.Drawing.Point(19, 17);
            this.btn_setinstallfolder.Name = "btn_setinstallfolder";
            this.btn_setinstallfolder.Size = new System.Drawing.Size(228, 23);
            this.btn_setinstallfolder.TabIndex = 17;
            this.btn_setinstallfolder.Text = "Set root Unity installations folder";
            this.toolTip1.SetToolTip(this.btn_setinstallfolder, "Basefolder where all your Unity installations are");
            this.btn_setinstallfolder.UseVisualStyleBackColor = true;
            this.btn_setinstallfolder.Click += new System.EventHandler(this.btn_setinstallfolder_Click);
            // 
            // txtRootFolder
            // 
            this.txtRootFolder.Enabled = false;
            this.txtRootFolder.Location = new System.Drawing.Point(19, 41);
            this.txtRootFolder.Name = "txtRootFolder";
            this.txtRootFolder.Size = new System.Drawing.Size(228, 20);
            this.txtRootFolder.TabIndex = 16;
            this.txtRootFolder.Text = "C:\\Program Files\\";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(253, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 23);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "R";
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
            ((System.ComponentModel.ISupportInitialize)(this.unityGridView)).EndInit();
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
        private System.Windows.Forms.Button btn_openFolder;
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
        private System.Windows.Forms.Button btn_setinstallfolder;
        private System.Windows.Forms.TextBox txtRootFolder;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView unityGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn _unityVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn _unityPath;
    }
}

