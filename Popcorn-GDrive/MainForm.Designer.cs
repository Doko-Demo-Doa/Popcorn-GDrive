namespace Popcorn_GDrive
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            this.localPathBrowseButton = new System.Windows.Forms.Button();
            this.topGroupBox = new System.Windows.Forms.GroupBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.fileExtensionLabel = new System.Windows.Forms.Label();
            this.fileExtensionTextBox = new System.Windows.Forms.TextBox();
            this.topGroupBoxLabel = new System.Windows.Forms.Label();
            this.folderPathTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.statusLabel = new System.Windows.Forms.Label();
            this.timerEditNotify = new System.Windows.Forms.Timer(this.components);
            this.logListBox = new System.Windows.Forms.ListBox();
            this.topGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // localPathBrowseButton
            // 
            this.localPathBrowseButton.Location = new System.Drawing.Point(395, 36);
            this.localPathBrowseButton.Name = "localPathBrowseButton";
            this.localPathBrowseButton.Size = new System.Drawing.Size(110, 23);
            this.localPathBrowseButton.TabIndex = 2;
            this.localPathBrowseButton.Text = "Browse folder...";
            this.localPathBrowseButton.UseVisualStyleBackColor = true;
            this.localPathBrowseButton.Click += new System.EventHandler(this.localPathBrowseButton_Click);
            // 
            // topGroupBox
            // 
            this.topGroupBox.Controls.Add(this.stopButton);
            this.topGroupBox.Controls.Add(this.startButton);
            this.topGroupBox.Controls.Add(this.fileExtensionLabel);
            this.topGroupBox.Controls.Add(this.fileExtensionTextBox);
            this.topGroupBox.Controls.Add(this.topGroupBoxLabel);
            this.topGroupBox.Controls.Add(this.folderPathTextBox);
            this.topGroupBox.Controls.Add(this.localPathBrowseButton);
            this.topGroupBox.Location = new System.Drawing.Point(12, 12);
            this.topGroupBox.Name = "topGroupBox";
            this.topGroupBox.Size = new System.Drawing.Size(511, 118);
            this.topGroupBox.TabIndex = 1;
            this.topGroupBox.TabStop = false;
            this.topGroupBox.Text = "General Settings";
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(314, 89);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(395, 89);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(110, 23);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Apply and Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // fileExtensionLabel
            // 
            this.fileExtensionLabel.AutoSize = true;
            this.fileExtensionLabel.Location = new System.Drawing.Point(3, 94);
            this.fileExtensionLabel.Name = "fileExtensionLabel";
            this.fileExtensionLabel.Size = new System.Drawing.Size(136, 13);
            this.fileExtensionLabel.TabIndex = 4;
            this.fileExtensionLabel.Text = "File Extension (without dot):";
            // 
            // fileExtensionTextBox
            // 
            this.fileExtensionTextBox.Location = new System.Drawing.Point(145, 91);
            this.fileExtensionTextBox.Name = "fileExtensionTextBox";
            this.fileExtensionTextBox.Size = new System.Drawing.Size(113, 20);
            this.fileExtensionTextBox.TabIndex = 3;
            // 
            // topGroupBoxLabel
            // 
            this.topGroupBoxLabel.AutoSize = true;
            this.topGroupBoxLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.topGroupBoxLabel.Location = new System.Drawing.Point(6, 22);
            this.topGroupBoxLabel.Name = "topGroupBoxLabel";
            this.topGroupBoxLabel.Size = new System.Drawing.Size(424, 13);
            this.topGroupBoxLabel.TabIndex = 2;
            this.topGroupBoxLabel.Text = "Please choose a folder to watch, all files in specified folder will be uploaded a" +
    "utomatically";
            // 
            // folderPathTextBox
            // 
            this.folderPathTextBox.Location = new System.Drawing.Point(6, 38);
            this.folderPathTextBox.Name = "folderPathTextBox";
            this.folderPathTextBox.Size = new System.Drawing.Size(383, 20);
            this.folderPathTextBox.TabIndex = 1;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Folder browser dialog for watcher";
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.statusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.statusLabel.Location = new System.Drawing.Point(407, 138);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(116, 13);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Status: On Hold";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerEditNotify
            // 
            this.timerEditNotify.Enabled = true;
            this.timerEditNotify.Tick += new System.EventHandler(this.timerEditNotify_Tick);
            // 
            // logListBox
            // 
            this.logListBox.FormattingEnabled = true;
            this.logListBox.Location = new System.Drawing.Point(12, 154);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(511, 95);
            this.logListBox.TabIndex = 7;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 258);
            this.Controls.Add(this.logListBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.topGroupBox);
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "Popcorn-GDrive";
            this.topGroupBox.ResumeLayout(false);
            this.topGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button localPathBrowseButton;
        private System.Windows.Forms.GroupBox topGroupBox;
        private System.Windows.Forms.TextBox folderPathTextBox;
        private System.Windows.Forms.Label topGroupBoxLabel;
        private System.Windows.Forms.TextBox fileExtensionTextBox;
        private System.Windows.Forms.Label fileExtensionLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Timer timerEditNotify;
        private System.Windows.Forms.ListBox logListBox;
    }
}

