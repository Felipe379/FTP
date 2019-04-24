namespace FTP
{
    partial class FrmMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Disconnect = new System.Windows.Forms.Button();
            this.txt_ServerName = new System.Windows.Forms.TextBox();
            this.chk_ShowPassword = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.lst_Filelist = new System.Windows.Forms.ListBox();
            this.btn_DownloadFiles = new System.Windows.Forms.Button();
            this.btn_UpdateFileList = new System.Windows.Forms.Button();
            this.btn_Upload = new System.Windows.Forms.Button();
            this.btn_NewFolder = new System.Windows.Forms.Button();
            this.btn_Rename = new System.Windows.Forms.Button();
            this.txt_FolderName = new System.Windows.Forms.TextBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.txt_Rename = new System.Windows.Forms.TextBox();
            this.txt_FtpCurrentDirectory = new System.Windows.Forms.TextBox();
            this.btn_Return = new System.Windows.Forms.Button();
            this.lbl_Details = new System.Windows.Forms.Label();
            this.lbl_TextDetails = new System.Windows.Forms.Label();
            this.btn_Copy = new System.Windows.Forms.Button();
            this.btn_Paste = new System.Windows.Forms.Button();
            this.chk_DeleteOriginalFiles = new System.Windows.Forms.CheckBox();
            this.lbl_TextTotal = new System.Windows.Forms.Label();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Disconnect);
            this.groupBox1.Controls.Add(this.txt_ServerName);
            this.groupBox1.Controls.Add(this.chk_ShowPassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btn_Connect);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_Password);
            this.groupBox1.Controls.Add(this.txt_Username);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.Location = new System.Drawing.Point(406, 56);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.Size = new System.Drawing.Size(75, 23);
            this.btn_Disconnect.TabIndex = 6;
            this.btn_Disconnect.Text = "Disconnect";
            this.btn_Disconnect.UseVisualStyleBackColor = true;
            this.btn_Disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // txt_ServerName
            // 
            this.txt_ServerName.Location = new System.Drawing.Point(39, 32);
            this.txt_ServerName.Name = "txt_ServerName";
            this.txt_ServerName.Size = new System.Drawing.Size(122, 20);
            this.txt_ServerName.TabIndex = 1;
            // 
            // chk_ShowPassword
            // 
            this.chk_ShowPassword.AutoSize = true;
            this.chk_ShowPassword.Location = new System.Drawing.Point(9, 60);
            this.chk_ShowPassword.Name = "chk_ShowPassword";
            this.chk_ShowPassword.Size = new System.Drawing.Size(102, 17);
            this.chk_ShowPassword.TabIndex = 4;
            this.chk_ShowPassword.Text = "Show Password";
            this.chk_ShowPassword.UseVisualStyleBackColor = true;
            this.chk_ShowPassword.CheckedChanged += new System.EventHandler(this.chk_ShowPassword_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "ftp://";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(327, 56);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(73, 23);
            this.btn_Connect.TabIndex = 5;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "FTP Server";
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(327, 32);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '•';
            this.txt_Password.Size = new System.Drawing.Size(154, 20);
            this.txt_Password.TabIndex = 3;
            // 
            // txt_Username
            // 
            this.txt_Username.Location = new System.Drawing.Point(167, 32);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(154, 20);
            this.txt_Username.TabIndex = 2;
            // 
            // lst_Filelist
            // 
            this.lst_Filelist.FormattingEnabled = true;
            this.lst_Filelist.HorizontalScrollbar = true;
            this.lst_Filelist.Location = new System.Drawing.Point(505, 64);
            this.lst_Filelist.Name = "lst_Filelist";
            this.lst_Filelist.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lst_Filelist.Size = new System.Drawing.Size(341, 134);
            this.lst_Filelist.TabIndex = 20;
            this.lst_Filelist.SelectedIndexChanged += new System.EventHandler(this.lst_Filelist_SelectedIndexChanged);
            this.lst_Filelist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lst_Filelist_MouseDoubleClick);
            // 
            // btn_DownloadFiles
            // 
            this.btn_DownloadFiles.Location = new System.Drawing.Point(12, 162);
            this.btn_DownloadFiles.Name = "btn_DownloadFiles";
            this.btn_DownloadFiles.Size = new System.Drawing.Size(99, 23);
            this.btn_DownloadFiles.TabIndex = 16;
            this.btn_DownloadFiles.Text = "Download Files";
            this.btn_DownloadFiles.UseVisualStyleBackColor = true;
            this.btn_DownloadFiles.Click += new System.EventHandler(this.btn_DownloadFiles_Click);
            // 
            // btn_UpdateFileList
            // 
            this.btn_UpdateFileList.Location = new System.Drawing.Point(199, 162);
            this.btn_UpdateFileList.Name = "btn_UpdateFileList";
            this.btn_UpdateFileList.Size = new System.Drawing.Size(75, 23);
            this.btn_UpdateFileList.TabIndex = 18;
            this.btn_UpdateFileList.Text = "Refresh";
            this.btn_UpdateFileList.UseVisualStyleBackColor = true;
            this.btn_UpdateFileList.Click += new System.EventHandler(this.btn_UpdateFileList_Click);
            // 
            // btn_Upload
            // 
            this.btn_Upload.Location = new System.Drawing.Point(118, 162);
            this.btn_Upload.Name = "btn_Upload";
            this.btn_Upload.Size = new System.Drawing.Size(75, 23);
            this.btn_Upload.TabIndex = 17;
            this.btn_Upload.Text = "Upload Files";
            this.btn_Upload.UseVisualStyleBackColor = true;
            this.btn_Upload.Click += new System.EventHandler(this.btn_Upload_Click);
            // 
            // btn_NewFolder
            // 
            this.btn_NewFolder.Location = new System.Drawing.Point(12, 104);
            this.btn_NewFolder.Name = "btn_NewFolder";
            this.btn_NewFolder.Size = new System.Drawing.Size(75, 23);
            this.btn_NewFolder.TabIndex = 9;
            this.btn_NewFolder.Text = "New folder";
            this.btn_NewFolder.UseVisualStyleBackColor = true;
            this.btn_NewFolder.Click += new System.EventHandler(this.btn_NewFolder_Click);
            // 
            // btn_Rename
            // 
            this.btn_Rename.Location = new System.Drawing.Point(12, 133);
            this.btn_Rename.Name = "btn_Rename";
            this.btn_Rename.Size = new System.Drawing.Size(75, 23);
            this.btn_Rename.TabIndex = 14;
            this.btn_Rename.Text = "Rename";
            this.btn_Rename.UseVisualStyleBackColor = true;
            this.btn_Rename.Click += new System.EventHandler(this.btn_Rename_Click);
            // 
            // txt_FolderName
            // 
            this.txt_FolderName.Location = new System.Drawing.Point(93, 106);
            this.txt_FolderName.Name = "txt_FolderName";
            this.txt_FolderName.Size = new System.Drawing.Size(100, 20);
            this.txt_FolderName.TabIndex = 10;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(339, 162);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(154, 23);
            this.btn_Delete.TabIndex = 19;
            this.btn_Delete.Text = "Delete Selected";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // txt_Rename
            // 
            this.txt_Rename.Location = new System.Drawing.Point(93, 135);
            this.txt_Rename.Name = "txt_Rename";
            this.txt_Rename.Size = new System.Drawing.Size(100, 20);
            this.txt_Rename.TabIndex = 15;
            // 
            // txt_FtpCurrentDirectory
            // 
            this.txt_FtpCurrentDirectory.Location = new System.Drawing.Point(505, 21);
            this.txt_FtpCurrentDirectory.Name = "txt_FtpCurrentDirectory";
            this.txt_FtpCurrentDirectory.ReadOnly = true;
            this.txt_FtpCurrentDirectory.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_FtpCurrentDirectory.Size = new System.Drawing.Size(260, 20);
            this.txt_FtpCurrentDirectory.TabIndex = 7;
            // 
            // btn_Return
            // 
            this.btn_Return.Location = new System.Drawing.Point(771, 19);
            this.btn_Return.Name = "btn_Return";
            this.btn_Return.Size = new System.Drawing.Size(75, 23);
            this.btn_Return.TabIndex = 8;
            this.btn_Return.Text = "Return";
            this.btn_Return.UseVisualStyleBackColor = true;
            this.btn_Return.Click += new System.EventHandler(this.btn_Return_Click);
            // 
            // lbl_Details
            // 
            this.lbl_Details.AutoEllipsis = true;
            this.lbl_Details.Location = new System.Drawing.Point(48, 191);
            this.lbl_Details.Name = "lbl_Details";
            this.lbl_Details.Size = new System.Drawing.Size(445, 13);
            this.lbl_Details.TabIndex = 14;
            this.lbl_Details.Text = "lbl_Details";
            // 
            // lbl_TextDetails
            // 
            this.lbl_TextDetails.AutoSize = true;
            this.lbl_TextDetails.Location = new System.Drawing.Point(9, 191);
            this.lbl_TextDetails.Name = "lbl_TextDetails";
            this.lbl_TextDetails.Size = new System.Drawing.Size(42, 13);
            this.lbl_TextDetails.TabIndex = 15;
            this.lbl_TextDetails.Text = "Details:";
            // 
            // btn_Copy
            // 
            this.btn_Copy.Location = new System.Drawing.Point(339, 104);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(73, 23);
            this.btn_Copy.TabIndex = 11;
            this.btn_Copy.Text = "Copy Files";
            this.btn_Copy.UseVisualStyleBackColor = true;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            // 
            // btn_Paste
            // 
            this.btn_Paste.Location = new System.Drawing.Point(418, 104);
            this.btn_Paste.Name = "btn_Paste";
            this.btn_Paste.Size = new System.Drawing.Size(75, 23);
            this.btn_Paste.TabIndex = 12;
            this.btn_Paste.Text = "Paste Files";
            this.btn_Paste.UseVisualStyleBackColor = true;
            this.btn_Paste.Click += new System.EventHandler(this.btn_Paste_Click);
            // 
            // chk_DeleteOriginalFiles
            // 
            this.chk_DeleteOriginalFiles.AutoSize = true;
            this.chk_DeleteOriginalFiles.Location = new System.Drawing.Point(339, 133);
            this.chk_DeleteOriginalFiles.Name = "chk_DeleteOriginalFiles";
            this.chk_DeleteOriginalFiles.Size = new System.Drawing.Size(114, 17);
            this.chk_DeleteOriginalFiles.TabIndex = 13;
            this.chk_DeleteOriginalFiles.Text = "Delete original files";
            this.chk_DeleteOriginalFiles.UseVisualStyleBackColor = true;
            // 
            // lbl_TextTotal
            // 
            this.lbl_TextTotal.AutoSize = true;
            this.lbl_TextTotal.Location = new System.Drawing.Point(505, 47);
            this.lbl_TextTotal.Name = "lbl_TextTotal";
            this.lbl_TextTotal.Size = new System.Drawing.Size(34, 13);
            this.lbl_TextTotal.TabIndex = 18;
            this.lbl_TextTotal.Text = "Total:";
            // 
            // lbl_Total
            // 
            this.lbl_Total.AutoEllipsis = true;
            this.lbl_Total.Location = new System.Drawing.Point(545, 47);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(301, 14);
            this.lbl_Total.TabIndex = 19;
            this.lbl_Total.Text = "lbl_Total";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 213);
            this.Controls.Add(this.lbl_Total);
            this.Controls.Add(this.lbl_TextTotal);
            this.Controls.Add(this.chk_DeleteOriginalFiles);
            this.Controls.Add(this.btn_Paste);
            this.Controls.Add(this.btn_Copy);
            this.Controls.Add(this.lbl_TextDetails);
            this.Controls.Add(this.lbl_Details);
            this.Controls.Add(this.btn_Return);
            this.Controls.Add(this.txt_FtpCurrentDirectory);
            this.Controls.Add(this.txt_Rename);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.txt_FolderName);
            this.Controls.Add(this.btn_Rename);
            this.Controls.Add(this.btn_NewFolder);
            this.Controls.Add(this.btn_Upload);
            this.Controls.Add(this.btn_UpdateFileList);
            this.Controls.Add(this.btn_DownloadFiles);
            this.Controls.Add(this.lst_Filelist);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FTP App";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.TextBox txt_ServerName;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.ListBox lst_Filelist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_DownloadFiles;
        private System.Windows.Forms.Button btn_UpdateFileList;
        private System.Windows.Forms.Button btn_Upload;
        private System.Windows.Forms.CheckBox chk_ShowPassword;
        private System.Windows.Forms.Button btn_NewFolder;
        private System.Windows.Forms.Button btn_Rename;
        private System.Windows.Forms.TextBox txt_FolderName;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.TextBox txt_Rename;
        private System.Windows.Forms.TextBox txt_FtpCurrentDirectory;
        private System.Windows.Forms.Button btn_Return;
        private System.Windows.Forms.Label lbl_Details;
        private System.Windows.Forms.Label lbl_TextDetails;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Button btn_Paste;
        private System.Windows.Forms.CheckBox chk_DeleteOriginalFiles;
        private System.Windows.Forms.Label lbl_TextTotal;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.Button btn_Disconnect;
    }
}

