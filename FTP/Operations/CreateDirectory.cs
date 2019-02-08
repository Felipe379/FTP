using System.Linq;
using System.Net;

namespace FTP.Operations
{
    public class CreateDirectory
    {
        public static void CreateFolder(FtpClient client, string folderName)
        {
            var count = 0;

            var currentDirectoryList = ListFiles.DirectoryListing(client, string.Empty);

            while (currentDirectoryList.Any(n => n.Name == folderName))
            {
                folderName = $"{folderName.Substring(0, 10)} ({++count})";
            }

            var request = (FtpWebRequest)WebRequest.Create($"{client.Host}{client.Path}/{folderName}");
            request.Credentials = new NetworkCredential(client.Username, client.Password);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;

            var ftpStream = (FtpWebResponse)request.GetResponse();
            ftpStream.Close();
        }
    }
}
