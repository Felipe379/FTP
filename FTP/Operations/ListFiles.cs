using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace FTP.Operations
{
    public class ListFiles
    {
        public static List<FileDetail.Details> DirectoryListing(FtpClient client, string folder)
        {
            var result = new List<FileDetail.Details>();
            var x = $"{client.Host}{client.Path}/{folder}";
            var request = (FtpWebRequest)WebRequest.Create($"{client.Host}{client.Path}/{folder}");
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.Credentials = new NetworkCredential(client.Username, client.Password);

            using (var responseStream = request.GetResponse().GetResponseStream())
            {
                using (var reader = new StreamReader(responseStream))
                {
                    while (!reader.EndOfStream)
                    {
                        result.Add(ParseDetails(reader.ReadLine()));
                    }
                }
            }

            return result;
        }

        public static FileDetail.Details ParseDetails(string detail)
        {
            var regex = @"^" +
                           @"(?<filetype>[\-ldpscbD])" +              // File type
                           @"(?<permission>[\-rwxsStT]{9})" +         // User, Group and Other permissions
                           @"(?<alternateaccessmethod>[@+\.]?)" +     // Altenate Access Method
                           @"\s+" +
                           @"(?<numberoflinks>\d+)" +                 // Number of links
                           @"\s+" +
                           @"(?<owner>\w+)" +                         // User name
                           @"\s+" +
                           @"(?<group>\w+)" +                         // Group name
                           @"\s+" +
                           @"(?<size>\d+)" +                          // File size
                           @"\s+" +
                           @"(?<month>\w{3})" +                       // Month (3 letters)
                           @"\s+" +
                           @"(?<day>\d{1,2})" +                       // Day (1 or 2 digits)
                           @"\s+" +
                           @"(?<timeyear>[\d:]{4,5})" +               // Time or year
                           @"\s+" +
                           @"(?<filename>(.*))" +                     // Filename
                           @"$";

            var token = new Regex(regex).Match(detail);
            var permissions = token.Groups["permission"].ToString();
            var alternateaccessmethod = token.Groups["alternateaccessmethod"].ToString();

            var fileDetail = new FileDetail.Details();

            fileDetail.ListDirectoryDetailsSummary = detail;

            fileDetail.FileType = GetFileType(Convert.ToChar(token.Groups["filetype"].ToString()));

            fileDetail.Owner.ReadPermission = GetPermissionType(permissions[0]);
            fileDetail.Owner.WritePermission = GetPermissionType(permissions[1]);
            fileDetail.Owner.ExecutePermission = GetPermissionType(permissions[2]);

            fileDetail.Group.ReadPermission = GetPermissionType(permissions[3]);
            fileDetail.Group.WritePermission = GetPermissionType(permissions[4]);
            fileDetail.Group.ExecutePermission = GetPermissionType(permissions[5]);

            fileDetail.Other.ReadPermission = GetPermissionType(permissions[6]);
            fileDetail.Other.WritePermission = GetPermissionType(permissions[7]);
            fileDetail.Other.ExecutePermission = GetPermissionType(permissions[8]);

            fileDetail.AlternateAccessMethod = GetAlternateAccessMethod(
                string.IsNullOrWhiteSpace(alternateaccessmethod) ? ' ' : Convert.ToChar(alternateaccessmethod));

            fileDetail.NumberOfLinks = Convert.ToInt32(token.Groups["numberoflinks"].ToString());
            fileDetail.OwnerName = token.Groups["owner"].ToString();
            fileDetail.GroupName = token.Groups["group"].ToString();
            fileDetail.Size = Convert.ToInt64(token.Groups["size"].ToString());

            var date = $"{token.Groups["month"]} {token.Groups["day"]} {token.Groups["timeyear"]}";

            if (DateTime.TryParseExact($"{date} {DateTime.Now.Year}", "MMM dd HH:mm yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out DateTime result))
                fileDetail.ModifiedDate = result;
            else
                fileDetail.ModifiedDate = DateTime.ParseExact(date, "MMM dd yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);

            fileDetail.Name = token.Groups["filename"].ToString();

            return fileDetail;
        }

        private static FileDetail.PermissionTypes? GetPermissionType(char permissionType)
        {
            switch (permissionType)
            {
                case ('r'):
                    return FileDetail.PermissionTypes.Readable;
                case ('w'):
                    return FileDetail.PermissionTypes.Writable;
                case ('x'):
                    return FileDetail.PermissionTypes.Executable;
                case ('s'):
                    return FileDetail.PermissionTypes.ExecutableSetuidSetgid;
                case ('S'):
                    return FileDetail.PermissionTypes.NotExecutableSetuidSetgid;
                case ('t'):
                    return FileDetail.PermissionTypes.ExecutableStickyBit;
                case ('T'):
                    return FileDetail.PermissionTypes.NotExecutableStickyBit;
                case ('-'):
                    return FileDetail.PermissionTypes.NotAllowed;
                default:
                    return null;
            }
        }

        private static FileDetail.FileTypes? GetFileType(char fileType)
        {
            switch (fileType)
            {
                case ('d'):
                    return FileDetail.FileTypes.Directory;
                case ('l'):
                    return FileDetail.FileTypes.SymbolicLink;
                case ('p'):
                    return FileDetail.FileTypes.NamedPipe;
                case ('s'):
                    return FileDetail.FileTypes.Socket;
                case ('c'):
                    return FileDetail.FileTypes.SpecialFileCharacter;
                case ('b'):
                    return FileDetail.FileTypes.SpecialFileBlock;
                case ('D'):
                    return FileDetail.FileTypes.Door;
                case ('-'):
                    return FileDetail.FileTypes.RegularFile;
                default:
                    return null;
            }
        }

        private static FileDetail.AlternateAccessMethod? GetAlternateAccessMethod(char alternateAccessMethodType)
        {
            switch (alternateAccessMethodType)
            {
                case (' '):
                    return FileDetail.AlternateAccessMethod.None;
                case ('@'):
                    return FileDetail.AlternateAccessMethod.ExtendedAttributes;
                case ('.'):
                    return FileDetail.AlternateAccessMethod.SecurityContext;
                case ('+'):
                    return FileDetail.AlternateAccessMethod.OtherAccessMethod;
                default:
                    return null;
            }
        }
    }
}
