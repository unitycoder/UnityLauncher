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
            this.lst_unitys = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_setinstallfolder
            // 
            this.btn_setinstallfolder.Location = new System.Drawing.Point(334, 28);
            this.btn_setinstallfolder.Name = "btn_setinstallfolder";
            this.btn_setinstallfolder.Size = new System.Drawing.Size(75, 23);
            this.btn_setinstallfolder.TabIndex = 0;
            this.btn_setinstallfolder.Text = "Set Folders";
            this.btn_setinstallfolder.UseVisualStyleBackColor = true;
            this.btn_setinstallfolder.Click += new System.EventHandler(this.btn_setinstallfolder_Click);
            // 
            // lst_unitys
            // 
            this.lst_unitys.FormattingEnabled = true;
            this.lst_unitys.Location = new System.Drawing.Point(198, 57);
            this.lst_unitys.Name = "lst_unitys";
            this.lst_unitys.Size = new System.Drawing.Size(211, 381);
            this.lst_unitys.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 451);
            this.Controls.Add(this.lst_unitys);
            this.Controls.Add(this.btn_setinstallfolder);
            this.Name = "Form1";
            this.Text = "UnityLauncher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_setinstallfolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox lst_unitys;
    }
}

