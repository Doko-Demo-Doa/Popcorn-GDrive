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
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Popcorn_GDrive
{
    public partial class mainForm : Form
    {
        private StringBuilder m_StringBuilder;
        private bool isFolderFilled;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private bool isFolderBeingWatched;
        private bool isLogListBoxFilled;

        public string[] fileNames;


        public mainForm()
        {
            InitializeComponent();
            folderPathTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            isFolderBeingWatched = false;
            m_StringBuilder = new StringBuilder();
            statusLabel.ForeColor = Color.Black;
            isLogListBoxFilled = false;
        }
     

        private void startButton_Click(object sender, EventArgs e)
        {

            if (Directory.Exists(folderPathTextBox.Text))
            {
                fileSystemWatcher = new System.IO.FileSystemWatcher();
                fileSystemWatcher.IncludeSubdirectories = true;
                isFolderBeingWatched = true;
                stopButton.Enabled = true; //Enable Stop button after pressing Start button
                startButton.Enabled = false; //Disable Start button itself after pressing

                fileSystemWatcher.Filter = "*.*";
                fileSystemWatcher.Path = folderPathTextBox.Text + "\\";

                fileSystemWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite |
                                                NotifyFilters.FileName | NotifyFilters.DirectoryName;

                fileSystemWatcher.Changed += new FileSystemEventHandler(OnChanged);
                fileSystemWatcher.Created += new FileSystemEventHandler(OnChanged);
                fileSystemWatcher.Deleted += new FileSystemEventHandler(OnChanged);

                fileSystemWatcher.EnableRaisingEvents = true;

                uploadFile(Authentication.AuthenticateOauth("955747678289-di31d331tfe81m0hdo77fhv8siphkq2d.apps.googleusercontent.com",
                                                            "ftRHdShzYZuHIDH9RckrfUcw","Doko"), "D:\\document.txt");
            }

            else
            {
                MessageBox.Show("Not good, check your file path again."); //Placeholder
            }

            logListBox.Text += ("WTF" + Environment.NewLine);
            statusLabel.Text = "Status: Processing";
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!isLogListBoxFilled)
            {
                m_StringBuilder.Remove(0, m_StringBuilder.Length);
                m_StringBuilder.Append(e.FullPath);
                m_StringBuilder.Append(" ");
                m_StringBuilder.Append(e.ChangeType.ToString());
                m_StringBuilder.Append("  |  ");
                m_StringBuilder.Append(DateTime.Now.ToString());
                isLogListBoxFilled = true;
            }

        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            fileSystemWatcher.EnableRaisingEvents = false;
            fileSystemWatcher.Dispose();
            stopButton.Enabled = false;
            startButton.Enabled = true;
            //MessageBox.Show("Stopped");
            isLogListBoxFilled = false;
            logListBox.Items.Clear();

            statusLabel.Text = "Stopped";
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

        private void timerEditNotify_Tick(object sender, EventArgs e)
        {
            if (isLogListBoxFilled)
            {
                logListBox.BeginUpdate();
                logListBox.Items.Add(m_StringBuilder.ToString());
                logListBox.EndUpdate();
                isLogListBoxFilled = false;
            }
        }
    }
}
