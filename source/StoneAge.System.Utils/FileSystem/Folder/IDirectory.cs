using System.Collections.Generic;

namespace StoneAge.System.Utils.FileSystem.Folder
{
    public interface IDirectory
    {
        string Location { get; set; }

        IEnumerable<FileInformation> List_Files();
        bool Exists();
    }
}
