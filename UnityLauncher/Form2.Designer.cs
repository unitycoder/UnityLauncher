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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Project Version:";
            // 
            // lstUnityVersions
            // 
            this.lstUnityVersions.FormattingEnabled = true;
            this.lstUnityVersions.Location = new System.Drawing.Point(15, 66);
            this.lstUnityVersions.Name = "lstUnityVersions";
            this.lstUnityVersions.Size = new System.Drawing.Size(237, 290);
            this.lstUnityVersions.TabIndex = 1;
            // 
            // btnCancelUpgrade
            // 
            this.btnCancelUpgrade.Location = new System.Drawing.Point(15, 362);
            this.btnCancelUpgrade.Name = "btnCancelUpgrade";
            this.btnCancelUpgrade.Size = new System.Drawing.Size(95, 56);
            this.btnCancelUpgrade.TabIndex = 2;
            this.btnCancelUpgrade.Text = "Cancel";
            this.btnCancelUpgrade.UseVisualStyleBackColor = true;
            // 
            // btnConfirmUpgrade
            // 
            this.btnConfirmUpgrade.Location = new System.Drawing.Point(116, 362);
            this.btnConfirmUpgrade.Name = "btnConfirmUpgrade";
            this.btnConfirmUpgrade.Size = new System.Drawing.Size(136, 56);
            this.btnConfirmUpgrade.TabIndex = 3;
            this.btnConfirmUpgrade.Text = "Upgrade";
            this.btnConfirmUpgrade.UseVisualStyleBackColor = true;
            // 
            // txtUpgradeCurrentVersion
            // 
            this.txtUpgradeCurrentVersion.Enabled = false;
            this.txtUpgradeCurrentVersion.Location = new System.Drawing.Point(136, 18);
            this.txtUpgradeCurrentVersion.Name = "txtUpgradeCurrentVersion";
            this.txtUpgradeCurrentVersion.Size = new System.Drawing.Size(100, 20);
            this.txtUpgradeCurrentVersion.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Available Unity Versions";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 426);
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
            this.Text = "Upgrade existing project";
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
    }
}