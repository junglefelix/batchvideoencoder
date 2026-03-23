using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchVideoEncoder
{
    public partial class SelectDestinationForm : Form
    {
        public SelectDestinationForm()
        {
            InitializeComponent();
            string settingsOutDir = Settings.Default.OutputDirectory;
            if (string.IsNullOrEmpty(settingsOutDir))
            {
            radioUseSrcFolder.Checked = true;

            }
            else
            {
                radioUseOutputFolder.Checked = true;
                tbOutputDir.Text = settingsOutDir;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // radioUseSrcFolder
            btnBrowseOutDir.Enabled = radioUseOutputFolder.Checked;
            tbOutputDir.Enabled = radioUseOutputFolder.Checked;
        }

        private void btnBrowseOutDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbOutputDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void radioUseOutputFolder_CheckedChanged(object sender, EventArgs e)
        {
            btnBrowseOutDir.Enabled = radioUseOutputFolder.Checked;
            tbOutputDir.Enabled = radioUseOutputFolder.Checked;
        }

        private void btnDstFormOk_Click(object sender, EventArgs e)
        {
            if (radioUseSrcFolder.Checked)
            {
                Settings.Default.OutputDirectory = string.Empty;
                Settings.Default.Save();
                this.Close();
            }
            if (radioUseOutputFolder.Checked)
            {
                string dir = tbOutputDir.Text;
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                Settings.Default.OutputDirectory = dir;
                Settings.Default.Save();
                this.Close();
            }
        }

        private void btnDstFormCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
