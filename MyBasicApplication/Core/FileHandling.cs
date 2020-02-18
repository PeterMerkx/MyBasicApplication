using Microsoft.Win32;
using MyBasicApplication.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyBasicApplication.Core
{
    public class FileHandling
    {
        private static string destDirectory;

        public static string SelectedFilenameFolder { get; private set; }
        public static string SelectedFileName { get; private set; }

        private static string _selectedfilename;
        private static string _selectedfilenameFull;

        public static string ApplFolder { get; private set; }

        public static void GetFile(string appFolder)
        {
            ApplFolder = appFolder;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = "*.*";
            dlg.Filter = "All Files (*.*)| *.*";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                // Open document 
                _selectedfilename = dlg.SafeFileName;
                _selectedfilenameFull = dlg.FileName;


                destDirectory = appFolder; // + "\\<subdirectory>";

                SelectedFilenameFolder = PartOfString.Left(_selectedfilenameFull, _selectedfilename.Length);
                SelectedFileName = _selectedfilename;

            }
            if (_selectedfilename != null)
            {
                //Go on from here with handeling your file();
            }

        }

    }
}
