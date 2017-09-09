using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // fill textbox
            txtUpgradeCurrentVersion.Text = currentVersion;

            // update unity installations list
            lstUnityVersions.Items.AddRange(Form1.unityList.Keys.ToArray());

            // show available versions, autoselect nearest one
            if (string.IsNullOrEmpty(currentVersion) == false)
            {
                string nearestVersion = Form1.FindNearestVersion(currentVersion, Form1.unityList.Keys.ToList());
                //Console.WriteLine("nearest:" + nearestVersion);

                // preselect most likely version
                int likelyIndex = lstUnityVersions.FindString(currentVersion);
                if (likelyIndex > -1)
                {
                    lstUnityVersions.SetSelected(likelyIndex, true);
                }
            }
            else // we dont know current version
            {

            }
        }

        private void btnConfirmUpgrade_Click(object sender, EventArgs e)
        {
            if (lstUnityVersions.SelectedIndex>-1)
            {
                currentVersion = lstUnityVersions.Items[lstUnityVersions.SelectedIndex].ToString();
                DialogResult = DialogResult.OK;
            }
            else
            {
                // no version selected
            }
        }

        private void btnCancelUpgrade_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
