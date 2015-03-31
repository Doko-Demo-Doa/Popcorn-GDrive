using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Popcorn_GDrive
{
    public partial class mainForm : Form
    {
        private bool isFolderFilled;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private bool isFolderBeingWatched;


        public mainForm()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            isFolderBeingWatched = true;
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            fileSystemWatcher.EnableRaisingEvents = false;
            fileSystemWatcher.Dispose();
        }

        private void localPathBrowseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            DialogResult resDialogResult = folderBrowserDialog.ShowDialog();
            if (resDialogResult.ToString() == "OK")
            {
                folderPathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
