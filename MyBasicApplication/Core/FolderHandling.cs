using Microsoft.Win32;
using System;
using System.IO;
using Prism.Events;
using Prism.Commands;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Diagnostics;
using MyBasicApplication.Properties;

namespace MyBasicApplication.Core
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