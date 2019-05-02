using System.IO;
using System.Threading.Tasks;

namespace StoneAge.System.Utils.FileSystem.File
{
    public class Document : IDocument
    {
        public string Name { get; set; }
        public byte[] Bytes { get; set; }
        public string Location { get; set; }

        public string Full_Path()
        {
            return Path.Combine(Location, Name);
        }

        public async Task Write()
        {
            Ensure_Directory_Structure_Exist(Location);

            using (var stream = new FileStream(Full_Path(), FileMode.Create))
            {
                await stream.WriteAsync(Bytes);
            }
        }
        
        public bool Exists()
        {
            return global::System.IO.File.Exists(Full_Path());
        }

        public void Delete()
        {
            if (global::System.IO.File.Exists(Full_Path()))
            {
                global::System.IO.File.Delete(Full_Path());
            }
        }

        private static void Ensure_Directory_Structure_Exist(string filePath)
        {
            var directoryPath = Path.GetDirectoryName(filePath);
            if (Directory_Does_Not_Exist(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        private static bool Directory_Does_Not_Exist(string pathParts)
        {
            return !Directory.Exists(pathParts);
        }
    }
}
