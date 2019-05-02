using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StoneAge.System.Utils.FileSystem.Folder
{
    public class Directory : IDirectory
    {
        public string Location { get; set; }

        public IEnumerable<FileInformation> List_Files()
        {
            var directoryInfo = new DirectoryInfo(Location);
            var fileInformation = directoryInfo
                .GetFiles()
                .Select(info => new FileInformation()
                {
                    Name = info.Name,
                    Size = Convert_Bytes_To_Megabytes(info.Length)
                });

            double Convert_Bytes_To_Megabytes(long bytes)
            {
                var fileSizeInKB = bytes / 1024;
                var fileSizeInMB = fileSizeInKB / 1024;
                return fileSizeInMB;
            }

            return fileInformation;
        }

        public bool Exists()
        {
            return global::System.IO.Directory.Exists(Location);
        }
    }
}
