namespace UnityLauncher
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstUnityVersions = new System.Windows.Forms.ListBox();
            this.btnCancelUpgrade = new System.Windows.Forms.Button();
            this.btnConfirmUpgrade = new System.Windows.Forms.Button();
            this.txtUpgradeCurrentVersion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_GoInstallMissingVersion = new System.Windows.Forms.Button();
            this.btn_OpenMissingVersionReleasePage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Project Version:";
            // 
            // lstUnityVersions
            // 
            this.lstUnityVersions.FormattingEnabled = true;
            this.lstUnityVersions.Location = new System.Drawing.Point(12, 104);
            this.lstUnityVersions.Name = "lstUnityVersions";
            this.lstUnityVersions.Size = new System.Drawing.Size(235, 303);
            this.lstUnityVersions.TabIndex = 1;
            // 
            // btnCancelUpgrade
            // 
            this.btnCancelUpgrade.Location = new System.Drawing.Point(12, 413);
            this.btnCancelUpgrade.Name = "btnCancelUpgrade";
            this.btnCancelUpgrade.Size = new System.Drawing.Size(95, 56);
            this.btnCancelUpgrade.TabIndex = 2;
            this.btnCancelUpgrade.Text = "Cancel";
            this.btnCancelUpgrade.UseVisualStyleBackColor = true;
            this.btnCancelUpgrade.Click += new System.EventHandler(this.btnCancelUpgrade_Click);
            // 
            // btnConfirmUpgrade
            // 
            this.btnConfirmUpgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmUpgrade.Location = new System.Drawing.Point(113, 413);
            this.btnConfirmUpgrade.Name = "btnConfirmUpgrade";
            this.btnConfirmUpgrade.Size = new System.Drawing.Size(136, 56);
            this.btnConfirmUpgrade.TabIndex = 3;
            this.btnConfirmUpgrade.Text = "Upgrade Project";
            this.btnConfirmUpgrade.UseVisualStyleBackColor = true;
            this.btnConfirmUpgrade.Click += new System.EventHandler(this.btnConfirmUpgrade_Click);
            // 
            // txtUpgradeCurrentVersion
            // 
            this.txtUpgradeCurrentVersion.Enabled = false;
            this.txtUpgradeCurrentVersion.Location = new System.Drawing.Point(136, 18);
            this.txtUpgradeCurrentVersion.Name = "txtUpgradeCurrentVersion";
            this.txtUpgradeCurrentVersion.Size = new System.Drawing.Size(111, 20);
            this.txtUpgradeCurrentVersion.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Available Unity Versions";
            // 
            // btn_GoInstallMissingVersion
            // 
            this.btn_GoInstallMissingVersion.Location = new System.Drawing.Point(136, 44);
            this.btn_GoInstallMissingVersion.Name = "btn_GoInstallMissingVersion";
            this.btn_GoInstallMissingVersion.Size = new System.Drawing.Size(111, 22);
            this.btn_GoInstallMissingVersion.TabIndex = 6;
            this.btn_GoInstallMissingVersion.Text = "Download && Install";
            this.btn_GoInstallMissingVersion.UseVisualStyleBackColor = true;
            this.btn_GoInstallMissingVersion.Click += new System.EventHandler(this.btn_GoInstallMissingVersion_Click);
            // 
            // btn_OpenMissingVersionReleasePage
            // 
            this.btn_OpenMissingVersionReleasePage.Location = new System.Drawing.Point(19, 44);
            this.btn_OpenMissingVersionReleasePage.Name = "btn_OpenMissingVersionReleasePage";
            this.btn_OpenMissingVersionReleasePage.Size = new System.Drawing.Size(111, 22);
            this.btn_OpenMissingVersionReleasePage.TabIndex = 7;
            this.btn_OpenMissingVersionReleasePage.Text = "Open Release Page";
            this.btn_OpenMissingVersionReleasePage.UseVisualStyleBackColor = true;
            this.btn_OpenMissingVersionReleasePage.Click += new System.EventHandler(this.btn_OpenMissingVersionReleasePage_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 476);
            this.Controls.Add(this.btn_OpenMissingVersionReleasePage);
            this.Controls.Add(this.btn_GoInstallMissingVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUpgradeCurrentVersion);
            this.Controls.Add(this.btnConfirmUpgrade);
            this.Controls.Add(this.btnCancelUpgrade);
            this.Controls.Add(this.lstUnityVersions);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Missing Exact Unity Version";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstUnityVersions;
        private System.Windows.Forms.Button btnCancelUpgrade;
        private System.Windows.Forms.Button btnConfirmUpgrade;
        private System.Windows.Forms.TextBox txtUpgradeCurrentVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_GoInstallMissingVersion;
        private System.Windows.Forms.Button btn_OpenMissingVersionReleasePage;
    }
}