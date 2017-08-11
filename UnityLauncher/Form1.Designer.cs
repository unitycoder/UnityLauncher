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
            ((System.ComponentModel.ISupportInitialize)(this.gridRecent)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_setinstallfolder
            // 
            this.btn_setinstallfolder.Location = new System.Drawing.Point(12, 12);
            this.btn_setinstallfolder.Name = "btn_setinstallfolder";
            this.btn_setinstallfolder.Size = new System.Drawing.Size(228, 23);
            this.btn_setinstallfolder.TabIndex = 2;
            this.btn_setinstallfolder.Text = "Set Root Installations Folder";
            this.btn_setinstallfolder.UseVisualStyleBackColor = true;
            this.btn_setinstallfolder.Click += new System.EventHandler(this.btn_setinstallfolder_Click);
            // 
            // txtRootFolder
            // 
            this.txtRootFolder.Enabled = false;
            this.txtRootFolder.Location = new System.Drawing.Point(12, 41);
            this.txtRootFolder.Name = "txtRootFolder";
            this.txtRootFolder.Size = new System.Drawing.Size(228, 20);
            this.txtRootFolder.TabIndex = 1;
            this.txtRootFolder.Text = "C:\\Program Files\\";
            // 
            // gridRecent
            // 
            this.gridRecent.AllowUserToAddRows = false;
            this.gridRecent.AllowUserToDeleteRows = false;
            this.gridRecent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRecent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._project,
            this._version,
            this._path,
            this._dateModified});
            this.gridRecent.Location = new System.Drawing.Point(12, 92);
            this.gridRecent.MultiSelect = false;
            this.gridRecent.Name = "gridRecent";
            this.gridRecent.ReadOnly = true;
            this.gridRecent.Size = new System.Drawing.Size(433, 347);
            this.gridRecent.TabIndex = 0;
            // 
            // _project
            // 
            this._project.HeaderText = "Project";
            this._project.Name = "_project";
            this._project.ReadOnly = true;
            this._project.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // _version
            // 
            this._version.HeaderText = "Version";
            this._version.Name = "_version";
            this._version.ReadOnly = true;
            this._version.Width = 70;
            // 
            // _path
            // 
            this._path.HeaderText = "Path";
            this._path.Name = "_path";
            this._path.ReadOnly = true;
            this._path.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._path.Width = 150;
            // 
            // _dateModified
            // 
            this._dateModified.HeaderText = "Modified";
            this._dateModified.Name = "_dateModified";
            this._dateModified.ReadOnly = true;
            this._dateModified.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._dateModified.Width = 70;
            // 
            // btnLaunch
            // 
            this.btnLaunch.Location = new System.Drawing.Point(12, 445);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(433, 35);
            this.btnLaunch.TabIndex = 1;
            this.btnLaunch.Text = "Launch!";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // lbl_unityCount
            // 
            this.lbl_unityCount.AutoSize = true;
            this.lbl_unityCount.Enabled = false;
            this.lbl_unityCount.Location = new System.Drawing.Point(246, 44);
            this.lbl_unityCount.Name = "lbl_unityCount";
            this.lbl_unityCount.Size = new System.Drawing.Size(97, 13);
            this.lbl_unityCount.TabIndex = 5;
            this.lbl_unityCount.Text = "Founded - versions";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 505);
            this.Controls.Add(this.lbl_unityCount);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.gridRecent);
            this.Controls.Add(this.txtRootFolder);
            this.Controls.Add(this.btn_setinstallfolder);
            this.Name = "Form1";
            this.Text = "UnityLauncher";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridRecent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_setinstallfolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtRootFolder;
        private System.Windows.Forms.DataGridView gridRecent;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.DataGridViewTextBoxColumn _project;
        private System.Windows.Forms.DataGridViewTextBoxColumn _version;
        private System.Windows.Forms.DataGridViewTextBoxColumn _path;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dateModified;
        private System.Windows.Forms.Label lbl_unityCount;
    }
}

