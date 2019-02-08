using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace FTP.Operations
{
    public class CopyPaste
    {
        public static void Copy(FtpClient client, List<string> files, bool deleteOriginalFiles)
        {
            var currentDirectoryList = ListFiles.DirectoryListing(client, string.Empty);

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);

                while (currentDirectoryList.Any(n => n.Name == fileName))
                    fileName = $"{fileName} - Copy";

                var request = (FtpWebRequest)WebRequest.Create($"{file}");
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(client.Username, client.Password);
                var response = (FtpWebResponse)request.GetResponse();

                using (var responseStream = response.GetResponseStream())
                {
                    Paste(client, ToByteArray(responseStream), fileName);
                }

                if (deleteOriginalFiles)
                {
                    var deleteRequest = (FtpWebRequest)WebRequest.Create($"{file}");
                    deleteRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                    deleteRequest.Credentials = new NetworkCredential(client.Username, client.Password);

                    deleteRequest.GetResponse();
                }
            }
        }

        private static byte[] ToByteArray(Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }

        private static bool Paste(FtpClient client, byte[] fileImage, string fileName)
        {
            var request = (FtpWebRequest)WebRequest.Create($"{client.Host}{client.Path}/{fileName}");
            request.Credentials = new NetworkCredential(client.Username, client.Password);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            using (var streamFile = request.GetRequestStream())
            {
                streamFile.Write(fileImage, 0, fileImage.Length);
            }

            return true;
        }
    }
}
