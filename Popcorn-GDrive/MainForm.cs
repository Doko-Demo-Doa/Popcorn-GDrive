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

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Net;

namespace Popcorn_GDrive
{
    public partial class mainForm : Form
    {
        private StringBuilder m_StringBuilder;
        private StringBuilder m_StringBuilder_FilePathOnly;
        private StringBuilder m_StringBuilder_FileExtensionOnly;
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
            m_StringBuilder_FilePathOnly = new StringBuilder();
            m_StringBuilder_FileExtensionOnly = new StringBuilder();
            statusLabel.ForeColor = Color.Black;
            isLogListBoxFilled = false;
        }

        DriveService service;

        string CLIENT_ID = " ";
        string CLIENT_SECRET = " ";

        private void startButton_Click(object sender, EventArgs e)
        {

            if (CheckInternetConnection() == true)
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

                    DriveService service =  Authentication.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, Environment.UserName);

                    if (service == null)
                        MessageBox.Show("Authentication Failed!");
                    else
                    {
                        authenticationLabel.ForeColor = Color.LimeGreen;
                        authenticationLabel.Text = "Authenticated";
                    }

                    //MessageBox.Show(folderPathTextBox.Text.ToString() + @"\document.txt");
                }

                else
                    MessageBox.Show("Not good, check your file path again."); //Placeholder
            }

            else
            {
                MessageBox.Show("Could not connect to Drive, please check your internet connection");
            }

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

                m_StringBuilder_FilePathOnly.Remove(0, m_StringBuilder_FilePathOnly.Length);
                m_StringBuilder_FilePathOnly.Append(e.FullPath);

                m_StringBuilder_FileExtensionOnly.Remove(0, m_StringBuilder_FileExtensionOnly.Length);
                m_StringBuilder_FileExtensionOnly.Append(Path.GetExtension(e.FullPath));

                MessageBox.Show(m_StringBuilder_FileExtensionOnly.ToString());

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

            statusLabel.Text = "Status: Stopped";

            if (Directory.Exists(@"C:\Users\Sophia\AppData\Roaming\Popcorn-GDrive.Auth.Store"))
            {
                Directory.Delete(@"C:\Users\Sophia\AppData\Roaming\Popcorn-GDrive.Auth.Store", true);
            }

            authenticationLabel.Text = "Deleted authentication cache";
            authenticationLabel.ForeColor = Color.Red;
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

                DriveService service = Authentication.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, Environment.UserName);
                String fileID = DriveFunctions.uploadFile(service, m_StringBuilder_FilePathOnly.ToString());
           

                //

                logListBox.EndUpdate();
                //System.IO.File.Delete(m_StringBuilder_FilePathOnly.ToString());
                isLogListBoxFilled = false;
            }
        }

        public static bool CheckInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream  = client.OpenRead("http://drive.google.com"))
                {
                    return true;
                }
            }

            catch
            {
                return false;
            }
        }
    }
}
