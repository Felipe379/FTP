using FTP.Operations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FTP
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            Disconnected();
        }

        private FtpClient Client;
        private List<FileDetail.Details> CurrentDirectoryFileList;
        private List<string> FilestoCopy;

        private void LoginSuccess()
        {
            txt_Username.Clear();
            txt_Password.Clear();
            lst_Filelist.Enabled = true;
            btn_Disconnect.Enabled = true;
            btn_UpdateFileList.Enabled = true;
            btn_Delete.Enabled = true;
            btn_DownloadFiles.Enabled = true;
            btn_NewFolder.Enabled = true;
            btn_Rename.Enabled = true;
            btn_Return.Enabled = true;
            btn_UpdateFileList.Enabled = true;
            btn_Upload.Enabled = true;
            btn_Copy.Enabled = true;
            btn_Paste.Enabled = true;
            txt_FolderName.Enabled = true;
            txt_Rename.Enabled = true;
            lbl_Details.Enabled = true;
            lbl_TextDetails.Enabled = true;
            lbl_Total.Enabled = true;
            lbl_TextTotal.Enabled = true;
            txt_FtpCurrentDirectory.Enabled = true;
            chk_DeleteOriginalFiles.Enabled = true;
        }

        private void Disconnected()
        {
            lst_Filelist.Items.Clear();
            txt_FolderName.Clear();
            txt_Rename.Clear();
            txt_FtpCurrentDirectory.Clear();
            Client = null;
            CurrentDirectoryFileList = null;
            FilestoCopy = null;
            lst_Filelist.Enabled = false;
            btn_Disconnect.Enabled = false;
            btn_UpdateFileList.Enabled = false;
            btn_Delete.Enabled = false;
            btn_DownloadFiles.Enabled = false;
            btn_NewFolder.Enabled = false;
            btn_Rename.Enabled = false;
            btn_Return.Enabled = false;
            btn_UpdateFileList.Enabled = false;
            btn_Upload.Enabled = false;
            btn_Copy.Enabled = false;
            btn_Paste.Enabled = false;
            txt_FolderName.Enabled = false;
            txt_Rename.Enabled = false;
            txt_FtpCurrentDirectory.Enabled = false;
            lbl_Details.Text = string.Empty;
            lbl_Details.Enabled = false;
            lbl_TextDetails.Enabled = false;
            lbl_Total.Text = string.Empty;
            lbl_Total.Enabled = false;
            lbl_TextTotal.Enabled = false;
            chk_DeleteOriginalFiles.Enabled = false;
            chk_DeleteOriginalFiles.Checked = false;
        }

        private void RefreshFileList()
        {
            CurrentDirectoryFileList = ListFiles.DirectoryListing(Client, string.Empty);

            lbl_Details.Text = string.Empty;

            lst_Filelist.BeginUpdate();
            lst_Filelist.Items.Clear();
            foreach (var file in CurrentDirectoryFileList)
            {
                lst_Filelist.Items.Add($"{file.Name}");
            }
            lst_Filelist.EndUpdate();

            txt_FtpCurrentDirectory.Text = Client.Host + Client.Path;
            lbl_Total.Text = CurrentDirectoryFileList.Count.ToString();
        }

        private DialogResult ExceptionCatchMessageBox(Exception ex, string Error) =>
            MessageBox.Show($"{Error}{Environment.NewLine}{Environment.NewLine}Exception Code:{Environment.NewLine}{ex}{Environment.NewLine}{Environment.NewLine}" +
            $"Some functions may not work properly. Would you like to continue to run the program anyway?",
            "Exception error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

        private void chk_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ShowPassword.Checked)
                txt_Password.PasswordChar = '\0';
            else
                txt_Password.PasswordChar = '•';
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txt_ServerName.Text))
                {
                    Disconnected();
                    Client = new FtpClient(txt_ServerName.Text.Trim(), txt_Username.Text.Trim(), txt_Password.Text.Trim());
                    RefreshFileList();
                    LoginSuccess();
                }
                else
                    MessageBox.Show("Please, fill the server name and the user name");
            }
            catch (Exception ex)
            {
                if (ExceptionCatchMessageBox(ex, "Failed to connect.") == DialogResult.No)
                    Application.Exit();
            }
        }

        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            Disconnected();
        }

        private void btn_UpdateFileList_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshFileList();
            }
            catch (Exception ex)
            {
                if (ExceptionCatchMessageBox(ex, "Failed to update files list.") == DialogResult.No)
                    Application.Exit();
            }
        }

        private void btn_DownloadFiles_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveFileDialog = new FolderBrowserDialog())
                {
                    var files = new List<string>();

                    if (lst_Filelist.SelectedIndex >= 0)
                    {
                        foreach (var selectedItem in lst_Filelist.SelectedItems)
                        {
                            files.Add(selectedItem.ToString());
                        }

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            var failedDownloads = Download.DownloadFiles(Client, saveFileDialog.SelectedPath, files);

                            if (failedDownloads.Any())
                            {
                                string toDisplay = string.Join(Environment.NewLine, failedDownloads);
                                MessageBox.Show($"Files failed to download:{Environment.NewLine}{toDisplay}");
                                RefreshFileList();
                            }
                            else
                            {
                                MessageBox.Show("All files downloaded.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please, select the file(s) to download.");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ExceptionCatchMessageBox(ex, "Failed to download files.") == DialogResult.No)
                    Application.Exit();
            }
        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            try
            {
                using (var selectFileDialog = new OpenFileDialog { Multiselect = true })
                {
                    if (selectFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var failedUploads = Upload.UploadFiles(Client, selectFileDialog.FileNames.ToList());

                        if (failedUploads.Any())
                        {
                            string toDisplay = string.Join(Environment.NewLine, failedUploads);
                            MessageBox.Show($"Files already exist:{Environment.NewLine}{toDisplay}");
                        }
                        else
                        {
                            MessageBox.Show("All files uploaded.");
                        }
                    }

                    RefreshFileList();
                };
            }
            catch (Exception ex)
            {
                if (ExceptionCatchMessageBox(ex, "Failed to upload files.") == DialogResult.No)
                    Application.Exit();
            }
        }

        private void btn_NewFolder_Click(object sender, EventArgs e)
        {
            try
            {
                var folderName = txt_FolderName.Text;
                var currentDirectoryList = ListFiles.DirectoryListing(Client, string.Empty);

                if (string.IsNullOrWhiteSpace(folderName))
                {
                    folderName = "New folder";
                    var count = 0;

                    while (currentDirectoryList.Any(n => n.Name == folderName))
                    {
                        folderName = $"{folderName.Substring(0, 10)} ({++count})";
                    }

                    CreateDirectory.CreateFolder(Client, folderName);
                    RefreshFileList();
                }
                else
                {
                    if (!Regex.IsMatch(folderName, "[\\/:*?\"<>|]"))
                    {
                        if (currentDirectoryList.Any(n => n.Name == folderName))
                        {
                            MessageBox.Show($"File or folder {Client.Host}{Client.Path}/{folderName} already exist.");
                        }
                        else
                        {
                            CreateDirectory.CreateFolder(Client, folderName);
                            RefreshFileList();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Folders can't have any of the following characters:{Environment.NewLine}\\ / : * ? \" < > |");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ExceptionCatchMessageBox(ex, "Failed to create folder.") == DialogResult.No)
                    Application.Exit();
            }
        }

        private void btn_Rename_Click(object sender, EventArgs e)
        {
            try
            {
                var name = txt_Rename.Text;
                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (lst_Filelist.SelectedIndex >= 0)
                    {
                        if (!Regex.IsMatch(name, "[\\/:*?\"<>|]"))
                        {
                            var result = Rename.RenameEntry(Client, name, CurrentDirectoryFileList[lst_Filelist.SelectedIndex].Name);
                            if (!string.IsNullOrWhiteSpace(result))
                            {
                                MessageBox.Show(result);
                            }
                            RefreshFileList();
                        }
                        else
                        {
                            MessageBox.Show($"Folders can't have any of the following characters:{Environment.NewLine}\\ / : * ? \" < > |");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please, select the file(s) or folder(s) to rename.");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ExceptionCatchMessageBox(ex, "Failed to rename.") == DialogResult.No)
                    Application.Exit();
            }
        }

        private void lst_Filelist_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lst_Filelist.SelectedIndex >= 0 && CurrentDirectoryFileList[lst_Filelist.SelectedIndex].FileType == FileDetail.FileTypes.Directory)
                {
                    Client.Path += lst_Filelist.SelectedItem.ToString() + "/";
                    RefreshFileList();
                }
            }
            catch (Exception ex)
            {
                if (ExceptionCatchMessageBox(ex, "Failed to list files.") == DialogResult.No)
                    Application.Exit();
            }
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Client.Path))
                {
                    string[] tokens = Client.Path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    Client.Path = string.Empty;
                    for (int i = 0; i < tokens.Length - 1; i++)
                    {
                        Client.Path += tokens[i] + "/";
                    }
                    RefreshFileList();
                }
            }
            catch (Exception ex)
            {
                if (ExceptionCatchMessageBox(ex, "Failed to return.") == DialogResult.No)
                    Application.Exit();
            }
        }

        private void lst_Filelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_Filelist.SelectedIndex >= 0)
            {
                lbl_Details.Text = CurrentDirectoryFileList[lst_Filelist.SelectedIndex].ListDirectoryDetailsSummary;
            }
            else
            {
                lbl_Details.Text = string.Empty;
            }
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            try
            {
                var filesNotFound = new List<string>();
                var currentDirectoryList = ListFiles.DirectoryListing(Client, string.Empty);

                FilestoCopy = new List<string>();

                foreach (var file in lst_Filelist.SelectedItems)
                {
                    if (!currentDirectoryList.Any(n => n.Name == file.ToString()) ||
                        currentDirectoryList.Any(n => n.Name == file.ToString() && n.FileType.Equals(FileDetail.FileTypes.Directory)))
                    {
                        filesNotFound.Add($"{Client.Host}{Client.Path}/{file}");
                        continue;
                    }
                    else
                    {
                        FilestoCopy.Add(Client.Host + Client.Path + file.ToString());
                    }
                }

                if (filesNotFound.Any())
                {
                    var toDisplay = string.Join(Environment.NewLine, filesNotFound);
                    MessageBox.Show($"Files failed to copy:{Environment.NewLine}{toDisplay}");
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                if (ExceptionCatchMessageBox(ex, "Failed to copy files.") == DialogResult.No)
                    Application.Exit();
            }
        }

        private void btn_Paste_Click(object sender, EventArgs e)
        {
            try
            {
                if (FilestoCopy != null)
                {
                    CopyPaste.Copy(Client, FilestoCopy, chk_DeleteOriginalFiles.Checked);
                    RefreshFileList();
                }
            }
            catch (Exception ex)
            {
                if (ExceptionCatchMessageBox(ex, "Failed to paste files.") == DialogResult.No)
                    Application.Exit();
            }

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedItems = CurrentDirectoryFileList.Where(f => lst_Filelist.SelectedItems.Contains(f.Name));

                if (lst_Filelist.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show($"Are you sure you want to delete the selected items permanently?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        var directories = new List<string>();
                        var files = new List<string>();
                        foreach (var item in selectedItems)
                        {
                            if (item.FileType == FileDetail.FileTypes.Directory)
                                directories.Add(item.Name.ToString());
                            else
                                files.Add(item.Name.ToString());
                        }

                        if (directories.Any())
                            Delete.DeleteDirectoriesRecursive(Client, directories, string.Empty);

                        if (files.Any())
                            Delete.DeleteFiles(Client, files);

                        RefreshFileList();
                    }
                }
                else
                {
                    MessageBox.Show("Please, select the file(s) or folder(s) to delete.");
                }
            }
            catch (Exception ex)
            {
                if (ExceptionCatchMessageBox(ex, "Failed to delete directories.") == DialogResult.No)
                    Application.Exit();
            }
        }
    }
}
