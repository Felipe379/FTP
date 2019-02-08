using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace FTP.Operations
{
    public class Download
    {
        public static List<string> DownloadFiles(FtpClient client, string saveFilePath, List<string> files)
        {
            var filesNotFound = new List<string>();
            var currentDirectoryList = ListFiles.DirectoryListing(client, string.Empty);

            foreach (var file in files)
            {
                if (!currentDirectoryList.Any(n => n.Name == file))
                {
                    filesNotFound.Add($"{client.Host}{client.Path}/{file}");
                    continue;
                }

                var request = (FtpWebRequest)WebRequest.Create($"{client.Host}{client.Path}/{file}");
                request.Credentials = new NetworkCredential(client.Username, client.Password);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                using (var ftpStream = request.GetResponse().GetResponseStream())
                {
                    using (var fileStream = File.Create($"{saveFilePath}/{file}"))
                    {
                        ftpStream.CopyTo(fileStream);
                    }
                }
            }

            return filesNotFound;
        }
    }
}
