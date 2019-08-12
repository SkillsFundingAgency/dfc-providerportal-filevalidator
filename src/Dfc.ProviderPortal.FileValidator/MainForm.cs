using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dfc.Providerportal.FileValidator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderLocation = new FolderBrowserDialog
            {
                SelectedPath = selectFileTextBox.Text
            };
            if (folderLocation.ShowDialog() == DialogResult.OK)
            {
                selectFileTextBox.Text = folderLocation.SelectedPath;
            }
        }
    }
}
