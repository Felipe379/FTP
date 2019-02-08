using System.Linq;
using System.Net;

namespace FTP.Operations
{
    public class CreateDirectory
    {
        public static void CreateFolder(FtpClient client, string folderName)
        {
            var request = (FtpWebRequest)WebRequest.Create($"{client.Host}{client.Path}/{folderName}");
            request.Credentials = new NetworkCredential(client.Username, client.Password);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;

            var ftpStream = (FtpWebResponse)request.GetResponse();
            ftpStream.Close();
        }
    }
}
