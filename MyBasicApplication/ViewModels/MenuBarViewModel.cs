using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using MyBasicApplication.Core;
using MyBasicApplication.Views;
using MyBasicApplication.Properties;
using MyBasicApplication.Converters;
using Prism.Events;
using System.Runtime.CompilerServices;
using MyBasicApplication.Library;
using System.IO;

namespace MyBasicApplication.ViewModels
{

    public class MenuBarViewModel : BindableBase
    {
        public string _menuItemFile;
        public string _menuItemNew;
        public string _menuItemBrowse;
        public string _menuItemExport;
        public string _menuItemSave;
        public string _menuItemExit;
        public string _menuItemEdit;
        public string _menuItemCut;
        public string _menuItemCopy;
        public string _menuItemPaste;
        public string _menuItemSettings;
        public string _menuItemLanguage;
        public string _menuItemNL;
        public string _menuItemEN;
        public string _menuItemWindow;
        public string _menuItemHelp;
        public string _menuItemAbout;
        public string _nlSelected;
        public string _enSelected;

        public bool _nlIsChecked;
        public bool _enIsChecked;

        public string MenuItemFile { get { return _menuItemFile; } set { SetProperty(ref _menuItemFile, value); } }
        public string MenuItemNew { get { return _menuItemNew; } set { SetProperty(ref _menuItemNew, value); } }
        public string MenuItemBrowse { get { return _menuItemBrowse; } set { SetProperty(ref _menuItemBrowse, value); } }
        public string MenuItemExport { get { return _menuItemExport; } set { SetProperty(ref _menuItemExport, value); } }
        public string MenuItemSave { get { return _menuItemSave; } set { SetProperty(ref _menuItemSave, value); } }
        public string MenuItemExit { get { return _menuItemExit; } set { SetProperty(ref _menuItemExit, value); } }
        public string MenuItemEdit { get { return _menuItemEdit; } set { SetProperty(ref _menuItemEdit, value); } }
        public string MenuItemCut { get { return _menuItemCut; } set { SetProperty(ref _menuItemCut, value); } }
        public string MenuItemCopy { get { return _menuItemCopy; } set { SetProperty(ref _menuItemCopy, value); } }
        public string MenuItemPaste { get { return _menuItemPaste; } set { SetProperty(ref _menuItemPaste, value); } }
        public string MenuItemSettings { get { return _menuItemSettings; } set { SetProperty(ref _menuItemSettings, value); } }
        public string MenuItemLanguage { get { return _menuItemLanguage; } set { SetProperty(ref _menuItemLanguage, value); } }
        public string MenuItemNL { get { return _menuItemNL; } set { SetProperty(ref _menuItemNL, value); } }
        public string MenuItemEN { get { return _menuItemEN; } set { SetProperty(ref _menuItemEN, value); } }
        public string MenuItemWindow { get { return _menuItemWindow; } set { SetProperty(ref _menuItemWindow, value); } }

        public string MenuItemWindow1 { get { return _menuItemWindow1; } set { SetProperty(ref _menuItemWindow1, value); } }
        public string MenuItemWindow2 { get { return _menuItemWindow2; } set { SetProperty(ref _menuItemWindow2, value); } }

        public string MenuItemHelp { get { return _menuItemHelp; } set { SetProperty(ref _menuItemHelp, value); } }
        public string MenuItemAbout { get { return _menuItemAbout; } set { SetProperty(ref _menuItemAbout, value); } }
        public string TxtMenuArea { get { return _txtMenuArea; } set { SetProperty(ref _txtMenuArea, value); } }
        public string NLSelected { get { return _nlSelected; } set { SetProperty(ref _nlSelected, value); } }
        public string ENSelected { get { return _enSelected; } set { SetProperty(ref _enSelected, value); } }

        private IRegionManager _regionManager;

        public ICommand NLCommand { get; private set; }
        public ICommand ENCommand { get; private set; }
        public ICommand NavigateToMainRegionViewCommand { get; private set; }
        public ICommand NavigateToSecondViewCommand { get; private set; }

        public DelegateCommand exitCommand;
        public DelegateCommand newCommand;
        public DelegateCommand saveCommand;
        public DelegateCommand browseCommand;
        public DelegateCommand helpCommand;
        public DelegateCommand InitializeCommand { get; private set; }

        public string appFolder;
        public IEventAggregator _ea;
        private string _menuItemWindow1;
        private string _menuItemWindow2;
        private string _txtMenuArea;

        public MenuBarViewModel(IRegionManager regionManager)
        {
            //InitializeCommand = new DelegateCommand(Initialize);
            //_ea = ea;
            _regionManager = regionManager;
            NLCommand = new DelegateCommand(cmdNL);
            ENCommand = new DelegateCommand(cmdEN);
            NavigateToMainRegionViewCommand = new DelegateCommand(() => NavigateTo("MainRegionView"));
            NavigateToSecondViewCommand = new DelegateCommand(() => NavigateTo("SecondView"));
            newCommand = new DelegateCommand(newCmd);
            browseCommand = new DelegateCommand(browseCmd);
            saveCommand = new DelegateCommand(saveCmd);
            helpCommand = new DelegateCommand(helpCmd);
            exitCommand = new DelegateCommand(exitCmd);
            SetItemsContent();


        }

        private void NavigateTo(string url)
        {
            _regionManager.RequestNavigate(Regions.MainRegion, url);
        }

        public void SetItemsContent()
        {
            //menulabels
            MenuItemNew = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemNew");
            MenuItemBrowse = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemBrowse");
            MenuItemExport = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemExport");
            MenuItemSave = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemSave");

            MenuItemExit = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemExit");
            MenuItemEdit = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemEdit");
            MenuItemCut = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemCut");
            MenuItemCopy = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemCopy");
            MenuItemPaste = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemPaste");
            MenuItemSettings = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemSettings");
            MenuItemLanguage = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemLanguage");
            MenuItemNL = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemNL");
            MenuItemEN = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemEN");
            MenuItemWindow = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemWindow");
            MenuItemWindow1 = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemWindow1");
            MenuItemWindow2 = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemWindow2");
            MenuItemHelp = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemHelp");
            MenuItemAbout = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemAbout");
            MenuItemFile = INIFile.ReadValue(MyLanguage, "MenuItems", "menuItemFile");
            TxtMenuArea = "MenuBar";

            if (MyLanguage == "Nederlands")
            {
                NLIsChecked = true;
                NLSelected = "Bold";
                ENIsChecked = false;
                ENSelected = "Normal";

            }
            else if (MyLanguage == "English")
            {
                NLIsChecked = false;
                NLSelected = "Normal";
                ENIsChecked = true;
                ENSelected = "Bold";
            }

        }
        public void cmdNL()
        {
            MyLanguage = "Nederlands";
            NLIsChecked = true;
            NLSelected = "Bold";
            ENIsChecked = false;
            ENSelected = "Normal";
            GlobalEvents.Instance.Publish(MyLanguage);
            SetItemsContent();
        }
        public void cmdEN()
        {
            MyLanguage = "English";
            NLIsChecked = false;
            NLSelected = "Normal";
            ENIsChecked = true;
            ENSelected = "Bold";
            GlobalEvents.Instance.Publish(MyLanguage);

            SetItemsContent();

        }
        public string MyLanguage
        {
            get { return Settings.Default.applanguage; }
            set
            {
                Settings.Default.applanguage = value;
                Settings.Default.Save();
                RaisePropertyChanged(nameof(MyLanguage));
                //ButtonBarViewModel bbvm = new ButtonBarViewModel(Settings.Default.applanguage);
            }
        }
        public bool NLIsChecked
        {
            get { return _nlIsChecked; }
            set
            {
                _nlIsChecked = value;
                RaisePropertyChanged(nameof(NLIsChecked));

            }
        }
        public bool ENIsChecked
        {
            get { return _enIsChecked; }
            set
            {
                _enIsChecked = value;
                RaisePropertyChanged(nameof(ENIsChecked));
            }
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
        public DelegateCommand HelpCommand
        {
            get { return helpCommand; }
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
        private void helpCmd()
        {
            MessageBox.Show("Help document getoond", "Info");

        }

        private void exitCmd()
        {
            Environment.Exit(0);
        }
        public void Initialize()
        {
            var dstDirectory = (GlobalVariables.RootPath);


        }

    }
}

