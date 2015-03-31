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
            this.localPathBrowseButton = new System.Windows.Forms.Button();
            this.topGroupBox = new System.Windows.Forms.GroupBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.fileExtensionLabel = new System.Windows.Forms.Label();
            this.fileExtensionTextBox = new System.Windows.Forms.TextBox();
            this.topGroupBoxLabel = new System.Windows.Forms.Label();
            this.folderPathTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.topGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // localPathBrowseButton
            // 
            this.localPathBrowseButton.Location = new System.Drawing.Point(395, 36);
            this.localPathBrowseButton.Name = "localPathBrowseButton";
            this.localPathBrowseButton.Size = new System.Drawing.Size(110, 23);
            this.localPathBrowseButton.TabIndex = 0;
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
            this.stopButton.TabIndex = 6;
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
            this.fileExtensionLabel.Size = new System.Drawing.Size(75, 13);
            this.fileExtensionLabel.TabIndex = 4;
            this.fileExtensionLabel.Text = "File Extension:";
            // 
            // fileExtensionTextBox
            // 
            this.fileExtensionTextBox.Location = new System.Drawing.Point(84, 91);
            this.fileExtensionTextBox.Name = "fileExtensionTextBox";
            this.fileExtensionTextBox.Size = new System.Drawing.Size(60, 20);
            this.fileExtensionTextBox.TabIndex = 3;
            // 
            // topGroupBoxLabel
            // 
            this.topGroupBoxLabel.AutoSize = true;
            this.topGroupBoxLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.topGroupBoxLabel.Location = new System.Drawing.Point(6, 22);
            this.topGroupBoxLabel.Name = "topGroupBoxLabel";
            this.topGroupBoxLabel.Size = new System.Drawing.Size(371, 13);
            this.topGroupBoxLabel.TabIndex = 2;
            this.topGroupBoxLabel.Text = "Please choose a folder to watch, specified files will be uploaded automatically";
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
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 258);
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
    }
}

