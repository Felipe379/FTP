using System.Linq;
using System.Net;

namespace FTP.Operations
{
    public class Rename
    {
        public static string RenameEntry(FtpClient client, string newName, string currentName)
        {
            var currentDirectoryList = ListFiles.DirectoryListing(client, string.Empty);

            if (!currentDirectoryList.Any(n => n.Name == currentName))
            {
                return $"File or folder {client.Host}{client.Path}/{currentName} doesn't exist.";
            }
            if (currentDirectoryList.Any(n => n.Name == newName))
            {
                return $"File or folder {client.Host}{client.Path}/{newName} already exist.";
            }

            var request = (FtpWebRequest)WebRequest.Create($"{client.Host}{client.Path}/{currentName}");
            request.Credentials = new NetworkCredential(client.Username, client.Password);
            request.Method = WebRequestMethods.Ftp.Rename;
            request.RenameTo = newName;

            var ftpStream = (FtpWebResponse)request.GetResponse();
            ftpStream.Close();

            return null;
        }
    }
}