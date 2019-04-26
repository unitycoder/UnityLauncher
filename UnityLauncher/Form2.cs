using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityLauncherTools;

namespace UnityLauncher
{
    public partial class Form2 : Form
    {
        public static string currentVersion = "";

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Start();
        }

        void Start()
        {
            // update unity installations list
            lstUnityVersions.Items.AddRange(Form1.unityList.Keys.ToArray());

            // show available versions, autoselect nearest one
            if (string.IsNullOrEmpty(currentVersion) == false)
            {
                string nearestVersion = Tools.FindNearestVersion(currentVersion, Form1.unityList.Keys.ToList());

                // preselect most likely version
                int likelyIndex = lstUnityVersions.FindString(nearestVersion);
                if (likelyIndex > -1)
                {
                    lstUnityVersions.SetSelected(likelyIndex, true);
                }
                else
                {
                    // just select first item then
                    lstUnityVersions.SetSelected(0, true);
                }

                // enable release and dl buttons
                btn_GoInstallMissingVersion.Enabled = true;
                btn_OpenMissingVersionReleasePage.Enabled = true;

            }
            else // we dont have current version
            {
                btn_GoInstallMissingVersion.Enabled = false;
                btn_OpenMissingVersionReleasePage.Enabled = false;

                currentVersion = "None";
                // just select first item then
                if (lstUnityVersions != null && lstUnityVersions.Items.Count > 0) lstUnityVersions.SetSelected(0, true);
            }

            // fill textbox
            txtUpgradeCurrentVersion.Text = currentVersion;
        }

        #region UI Events

        private void btnConfirmUpgrade_Click(object sender, EventArgs e)
        {
            UpgradeToSelected();
        }

        private void btnCancelUpgrade_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btn_OpenMissingVersionReleasePage_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore; // opens release notes
        }

        private void btn_GoInstallMissingVersion_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry; // download package
        }

        #endregion

        private void lstUnityVersions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                UpgradeToSelected();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        void UpgradeToSelected()
        {
            if (lstUnityVersions.SelectedIndex > -1)
            {
                currentVersion = lstUnityVersions.Items[lstUnityVersions.SelectedIndex].ToString();
                DialogResult = DialogResult.Yes;
            }
            else
            {
                // no version selected
            }
        }
    }
}
