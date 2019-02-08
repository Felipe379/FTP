using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace FTP.Operations
{
    public class Upload
    {
        public static List<string> UploadFiles(FtpClient client, List<string> files)
        {
            var filesAlreadyExists = new List<string>();
            var currentDirectoryList = ListFiles.DirectoryListing(client, string.Empty);

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);

                if (currentDirectoryList.Any(n => n.Name == fileName))
                {
                    filesAlreadyExists.Add(file);
                    continue;
                }

                var request = (FtpWebRequest)WebRequest.Create($"{client.Host}{client.Path}/{fileName}");
                request.Credentials = new NetworkCredential(client.Username, client.Password);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                using (var fileStream = File.OpenRead(file))
                {
                    using (var ftpStream = request.GetRequestStream())
                    {
                        fileStream.CopyTo(ftpStream);
                    }
                }
            }

            return filesAlreadyExists;
        }
    }
}
