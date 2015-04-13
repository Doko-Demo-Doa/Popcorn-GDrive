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
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Popcorn_GDrive
{
    public partial class mainForm : Form
    {
        private StringBuilder m_Sb;
        private bool isFolderFilled;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private bool isFolderBeingWatched;


        public mainForm()
        {
            InitializeComponent();
            folderPathTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            isFolderBeingWatched = false;
            m_Sb = new StringBuilder();

            statusLabel.ForeColor = Color.Black;
        }
     

        private void startButton_Click(object sender, EventArgs e)
        {

            if (Directory.Exists(folderPathTextBox.Text))
            {
                isFolderBeingWatched = true;
                    //fileSystemWatcher.EnableRaisingEvents = true;
                stopButton.Enabled = true; //Enable Stop button after pressing Start button
                startButton.Enabled = false; //Disable Start button itself after pressing
            }

            else
            {
                MessageBox.Show("Not good, check your file path again."); //Placeholder
            }

            logTextBox.Text += ("WTF" + Environment.NewLine);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            /*fileSystemWatcher.EnableRaisingEvents = false;
            fileSystemWatcher.Dispose();*/
            stopButton.Enabled = false;
            startButton.Enabled = true;
            MessageBox.Show("Stopped");

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
