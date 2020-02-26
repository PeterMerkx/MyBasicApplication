using MyBasicApplication.Converters;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Events;
using MyBasicApplication.Library;

namespace MyBasicApplication.ViewModels
{
    public class ButtonBarViewModel : BindableBase
    {
        public DelegateCommand exitCommand;
        public DelegateCommand newCommand;
        public DelegateCommand saveCommand;
        public DelegateCommand browseCommand;
        public string _appFolder;
        public string _buttonNew;
        public string _buttonBrowse;
        public string _buttonSave;
        public string _buttonExport;
        public string _buttonExit;
        public string _txtButtonArea;

        

        public string ButtonNew { get { return _buttonNew; } set { SetProperty(ref _buttonNew, value); }  }
        public string ButtonBrowse { get { return _buttonBrowse; } set { SetProperty(ref _buttonBrowse, value); } }
        public string ButtonSave { get { return _buttonSave; } set { SetProperty(ref _buttonSave, value); } }
        public string ButtonExport { get { return _buttonExport; } set { SetProperty(ref _buttonExport, value); } }
        public string ButtonExit {  get { return _buttonExit; } set { SetProperty(ref _buttonExit, value); } }
        public string TxtButtonArea { get { return _txtButtonArea; } set { SetProperty(ref _txtButtonArea, value); } }

        public ButtonBarViewModel()
        {
            newCommand = new DelegateCommand(newCmd);
            browseCommand = new DelegateCommand(browseCmd);
            saveCommand = new DelegateCommand(saveCmd);
            exitCommand = new DelegateCommand(exitCmd);
            GlobalEvents.Instance.Subscribe(ProcessLanguage);
            SetItemsContent();
        }

        private void ProcessLanguage(string language)
        {
            MyLanguage = language;
            SetItemsContent();
        }

        private void SetLanguage(string parameter)
        {
            MyLanguage = parameter;
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
            _appFolder = Settings.Default.appfolder;
            FileHandling.GetFile(_appFolder);
        }
        private void saveCmd()
        {
            MessageBox.Show("New document saved", "Info");

        }

        private void exitCmd()
        {
            Environment.Exit(0);
        }

        public void SetItemsContent()
        {
            //menulabels
            ButtonNew = INIFile.ReadValue(MyLanguage, "Buttons", "cmdNew");
            ButtonBrowse = INIFile.ReadValue(MyLanguage, "Buttons", "cmdBrowse");
            ButtonSave = INIFile.ReadValue(MyLanguage, "Buttons", "cmdSave");
            ButtonExport = INIFile.ReadValue(MyLanguage, "Buttons", "cmdExport");
            ButtonExit = INIFile.ReadValue(MyLanguage, "Buttons", "cmdQuit");
            TxtButtonArea = INIFile.ReadValue(MyLanguage, "Labels", "txtButtonArea");

        }
        public string MyLanguage
        {
            get { return Settings.Default.applanguage; }
            set
            {
                Settings.Default.applanguage = value;
                Settings.Default.Save();
                RaisePropertyChanged(nameof(MyLanguage));
            }
        }

    }

}
