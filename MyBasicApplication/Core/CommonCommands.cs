using MyBasicApplication.Properties;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyBasicApplication.Core
{
    public class CommonCommands
    {
        public static DelegateCommand exitCommand;
        public static DelegateCommand newCommand;
        public static DelegateCommand saveCommand;
        public static DelegateCommand browseCommand;
        public static string appFolder;

        public static void CommandNew()
        {
            newCommand = new DelegateCommand(newCmd);
        }
        
        public static void CommandBrowse()
        {
            browseCommand = new DelegateCommand(browseCmd);

        }

        public static void CommandSave()
        {
            saveCommand = new DelegateCommand(saveCmd);

        }

        public static void CommandExit()
        {
            exitCommand = new DelegateCommand(exitCmd);

        }

        public static DelegateCommand NewCommand
        {
            get { return newCommand; }
        }
        public static DelegateCommand BrowseCommand
        {
            get { return browseCommand; }
        }
        public static DelegateCommand SaveCommand
        {
            get { return saveCommand; }
        }
        public static DelegateCommand ExitCommand
        {
            get { return exitCommand; }
        }
        private static void newCmd()
        {
            MessageBox.Show("New document started", "Info");
        }
        private static void browseCmd()
        {
            appFolder = Settings.Default.appfolder;
            FileHandling.GetFile(appFolder);
        }
        private static void saveCmd()
        {
            MessageBox.Show("New document saved", "Info");

        }

        private static void exitCmd()
        {
            Environment.Exit(0);
        }

    }
}
