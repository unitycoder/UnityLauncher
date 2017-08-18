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
            this.btn_setinstallfolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtRootFolder = new System.Windows.Forms.TextBox();
            this.gridRecent = new System.Windows.Forms.DataGridView();
            this._project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dateModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.lbl_unityCount = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_openFolder = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridRecent)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_setinstallfolder
            // 
            this.btn_setinstallfolder.Location = new System.Drawing.Point(12, 12);
            this.btn_setinstallfolder.Name = "btn_setinstallfolder";
            this.btn_setinstallfolder.Size = new System.Drawing.Size(228, 23);
            this.btn_setinstallfolder.TabIndex = 2;
            this.btn_setinstallfolder.Text = "Set root Unity installations folder";
            this.toolTip1.SetToolTip(this.btn_setinstallfolder, "Basefolder where all your Unity installations are");
            this.btn_setinstallfolder.UseVisualStyleBackColor = true;
            this.btn_setinstallfolder.Click += new System.EventHandler(this.btn_setinstallfolder_Click);
            // 
            // txtRootFolder
            // 
            this.txtRootFolder.Enabled = false;
            this.txtRootFolder.Location = new System.Drawing.Point(12, 36);
            this.txtRootFolder.Name = "txtRootFolder";
            this.txtRootFolder.Size = new System.Drawing.Size(228, 20);
            this.txtRootFolder.TabIndex = 1;
            this.txtRootFolder.Text = "C:\\Program Files\\";
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
            this.gridRecent.Location = new System.Drawing.Point(12, 67);
            this.gridRecent.MultiSelect = false;
            this.gridRecent.Name = "gridRecent";
            this.gridRecent.ReadOnly = true;
            this.gridRecent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridRecent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRecent.ShowCellErrors = false;
            this.gridRecent.ShowCellToolTips = false;
            this.gridRecent.ShowEditingIcon = false;
            this.gridRecent.Size = new System.Drawing.Size(520, 433);
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
            // btnLaunch
            // 
            this.btnLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch.Location = new System.Drawing.Point(12, 506);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(434, 35);
            this.btnLaunch.TabIndex = 1;
            this.btnLaunch.Text = "Launch Project";
            this.toolTip1.SetToolTip(this.btnLaunch, "Launch selected project");
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // lbl_unityCount
            // 
            this.lbl_unityCount.AutoSize = true;
            this.lbl_unityCount.Enabled = false;
            this.lbl_unityCount.Location = new System.Drawing.Point(276, 17);
            this.lbl_unityCount.Name = "lbl_unityCount";
            this.lbl_unityCount.Size = new System.Drawing.Size(97, 13);
            this.lbl_unityCount.TabIndex = 5;
            this.lbl_unityCount.Text = "Founded - versions";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
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
            // btn_openFolder
            // 
            this.btn_openFolder.Location = new System.Drawing.Point(452, 506);
            this.btn_openFolder.Name = "btn_openFolder";
            this.btn_openFolder.Size = new System.Drawing.Size(80, 35);
            this.btn_openFolder.TabIndex = 7;
            this.btn_openFolder.Text = "Explore";
            this.toolTip1.SetToolTip(this.btn_openFolder, "Open File Explorer");
            this.btn_openFolder.UseVisualStyleBackColor = true;
            this.btn_openFolder.Click += new System.EventHandler(this.btn_openFolder_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(246, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 23);
            this.btnRefresh.TabIndex = 8;
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
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 566);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btn_openFolder);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbl_unityCount);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.gridRecent);
            this.Controls.Add(this.txtRootFolder);
            this.Controls.Add(this.btn_setinstallfolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "UnityLauncher - Potato Edition 2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gridRecent)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_setinstallfolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtRootFolder;
        private System.Windows.Forms.DataGridView gridRecent;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Label lbl_unityCount;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btn_openFolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn _project;
        private System.Windows.Forms.DataGridViewTextBoxColumn _version;
        private System.Windows.Forms.DataGridViewTextBoxColumn _path;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dateModified;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

