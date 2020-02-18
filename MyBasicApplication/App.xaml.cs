using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.Ioc;
using MyBasicApplication.Views;

namespace MyBasicApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
       protected override Window CreateShell()
        {
            
            var Shell = Container.Resolve<MainWindow>();
            return Shell;
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MenuBarView>("MenuBarView");
            containerRegistry.RegisterForNavigation<ButtonBarView>("ButtonBarView");
            containerRegistry.RegisterForNavigation<MainRegionView>("MainRegionView");
        }

    }
}
