using System.Collections.Generic;
using System.Net;

namespace FTP.Operations
{
    public class Delete
    {
        public static void DeleteDirectoriesRecursive(FtpClient client, List<string> directories, string path)
        {
            foreach (var directory in directories)
            {
                var url = $"{client.Host}{client.Path}/{path}{directory}";
                var lines = ListFiles.DirectoryListing(client, path + directory);

                foreach (var line in lines)
                {
                    var name = line.Name;

                    if (line.FileType == FileDetail.FileTypes.Directory)
                    {
                        DeleteDirectoriesRecursive(client, new List<string> { name }, $"{path}{directory}/");
                    }
                    else
                    {
                        var deleteRequest = (FtpWebRequest)WebRequest.Create($"{url}/{name}");
                        deleteRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                        deleteRequest.Credentials = new NetworkCredential(client.Username, client.Password);

                        deleteRequest.GetResponse();
                    }
                }

                var removeRequest = (FtpWebRequest)WebRequest.Create(url);
                removeRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;
                removeRequest.Credentials = new NetworkCredential(client.Username, client.Password);

                removeRequest.GetResponse();
            }
        }

        public static void DeleteDirectories(FtpClient client, List<string> directories)
        {
            foreach (var directory in directories)
            {
                var request = (FtpWebRequest)WebRequest.Create($"{client.Host}{client.Path}/{directory}");
                request.Method = WebRequestMethods.Ftp.RemoveDirectory;
                request.Credentials = new NetworkCredential(client.Username, client.Password);

                request.GetResponse();
            }
        }

        public static void DeleteFiles(FtpClient client, List<string> files)
        {
            foreach (var file in files)
            {
                var request = (FtpWebRequest)WebRequest.Create($"{client.Host}{client.Path}/{file}");
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(client.Username, client.Password);

                request.GetResponse();
            }
        }
    }
}
