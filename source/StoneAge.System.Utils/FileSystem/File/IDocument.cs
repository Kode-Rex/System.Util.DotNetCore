using System.Threading.Tasks;

namespace StoneAge.System.Utils.FileSystem.File
{
    public interface IDocument
    {
        string Name { get; set; }
        byte[] Bytes { get; set; }
        string Location { get; set; }

        string Full_Path();

        Task Write();
        bool Exists();
        void Delete();
    }
}