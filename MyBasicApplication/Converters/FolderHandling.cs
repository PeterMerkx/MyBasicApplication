using System.IO;

namespace MyBasicApplication.Converters
{
    public class FolderHandling
    {
        public static void createFolder(string destination)
        {
            if (!Directory.Exists(@destination))
            {
                Directory.CreateDirectory(@destination);
            }
            else
            {
                clearFolder(destination);
            }
        }

        public static void clearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                clearFolder(di.FullName);
                di.Delete();
            }
        }

    }
}