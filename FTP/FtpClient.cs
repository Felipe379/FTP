namespace FTP
{
    public class FtpClient
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Path { get; set; }

        public FtpClient(string host, string username, string password)
        {
            if (!host.EndsWith("/"))
                host = $"{host}/";

            if (!host.Contains("ftp://"))
                host = $"ftp://{host}";

            Host = host;
            Username = username;
            Password = password;
        }
    }
}
