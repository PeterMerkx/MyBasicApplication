using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyBasicApplication.Core;
using MyBasicApplication.Views;
using Prism.Commands;
using System.Windows.Input;


namespace MyBasicApplication.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public MainWindowViewModel(IRegionManager regionManager)
        {
            
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion(Regions.MainRegion, typeof(MainRegionView));
            _regionManager.RegisterViewWithRegion(Regions.MenuBarRegion, typeof(MenuBarView));
            _regionManager.RegisterViewWithRegion(Regions.ButtonBarRegion, typeof(ButtonBarView));
            //_regionManager.RegisterViewWithRegion(Regions.MainRegion, typeof(MediaResourceView));

        }

    }
}
