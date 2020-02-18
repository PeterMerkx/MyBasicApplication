using MyBasicApplication.Core;
using MyBasicApplication.Properties;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyBasicApplication.ViewModels
{
    public class ButtonBarViewModel : BindableBase
    {
        public DelegateCommand exitCommand;
        public DelegateCommand newCommand;
        public DelegateCommand saveCommand;
        public DelegateCommand browseCommand;
        public string appFolder;

        public ButtonBarViewModel()
        {
            newCommand = new DelegateCommand(newCmd);
            browseCommand = new DelegateCommand(browseCmd);
            saveCommand = new DelegateCommand(saveCmd);
            exitCommand = new DelegateCommand(exitCmd);

        }
        public DelegateCommand NewCommand
        {
            get { return newCommand; }
        }
        public DelegateCommand BrowseCommand
        {
            get { return browseCommand; }
        }
        public DelegateCommand SaveCommand
        {
            get { return saveCommand; }
        }
        public DelegateCommand ExitCommand
        {
            get { return exitCommand; }
        }
        private void newCmd()
        {
            MessageBox.Show("New document started", "Info");
        }
        private void browseCmd()
        {
            appFolder = Settings.Default.appfolder;
            FileHandling.GetFile(appFolder);
        }
        private void saveCmd()
        {
            MessageBox.Show("New document saved", "Info");

        }

        private void exitCmd()
        {
            Environment.Exit(0);
        }
    }
}
