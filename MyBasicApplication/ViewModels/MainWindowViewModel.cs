using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyBasicApplication.Library;
using MyBasicApplication.Views;
using Prism.Commands;
using System.Windows.Input;
using MyBasicApplication.Properties;
using MyBasicApplication.Converters;
using Prism.Events;

namespace MyBasicApplication.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public string ApplDirectory { get { return _applDirectory; } set { SetProperty(ref _applDirectory, value); } }
        private readonly IRegionManager _regionManager;
        private string _applDirectory;

        public MainWindowViewModel(IRegionManager regionManager,  IEventAggregator eventAggragator)
        {
            ApplDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MyBasicApplication"; // Change "\\MyBasicApplication" to set correct application folder
            Settings.Default.appfolder = ApplDirectory;
            Settings.Default.Save();
            //FolderHandling.createFolder(ApplDirectory ); // Add + "\\<subdirectory>" for extra subdirectory
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion(Regions.MainRegion, typeof(MainRegionView));
            _regionManager.RegisterViewWithRegion(Regions.MenuBarRegion, typeof(MenuBarView));
            _regionManager.RegisterViewWithRegion(Regions.ButtonBarRegion, typeof(ButtonBarView));
            //_regionManager.RegisterViewWithRegion(Regions.MainRegion, typeof(SecondView));

        }

    }
}
