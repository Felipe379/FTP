using System;

namespace FTP
{
    public class FileDetail
    {
        public enum FileTypes
        {
            RegularFile = '-',
            Directory = 'd',
            SymbolicLink = 'l',
            NamedPipe = 'p',
            Socket = 's',
            SpecialFileCharacter = 'c',
            SpecialFileBlock = 'b',
            Door = 'D',
        }

        public enum PermissionTypes
        {
            NotAllowed = '-',
            Readable = 'r',
            Writable = 'w',
            Executable = 'x',
            ExecutableSetuidSetgid = 's',
            NotExecutableSetuidSetgid = 'S',
            ExecutableStickyBit = 't',
            NotExecutableStickyBit = 'T',
        }

        public enum AlternateAccessMethod
        {
            None = ' ',
            ExtendedAttributes = '@',
            SecurityContext = '.',
            OtherAccessMethod = '+'
        }

        public class Permissions
        {
            public PermissionTypes? ReadPermission { get; set; }
            public PermissionTypes? WritePermission { get; set; }
            public PermissionTypes? ExecutePermission { get; set; }
        }

        public class Details
        {
            public string ListDirectoryDetailsSummary { get; set; }

            public FileTypes? FileType { get; set; }
            public Permissions Owner { get; set; } = new Permissions();
            public Permissions Group { get; set; } = new Permissions();
            public Permissions Other { get; set; } = new Permissions();

            public AlternateAccessMethod? AlternateAccessMethod { get; set; }

            public string OwnerName { get; set; }
            public string GroupName { get; set; }

            public int NumberOfLinks { get; set; }
            public long Size { get; set; } //Size in bytes
            public DateTime ModifiedDate { get; set; }
            public string Name { get; set; }
        }

    }
}
