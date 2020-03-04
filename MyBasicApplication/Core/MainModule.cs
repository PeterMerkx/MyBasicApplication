using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using MyBasicApplication.Views;
using Prism.Autofac;

namespace MyBasicApplication.Core
{
    class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var region = containerProvider.Resolve<IRegionManager>();
            region.RegisterViewWithRegion("MainRegion", typeof(MainRegionView));
            region.RegisterViewWithRegion("MenuRegion", typeof(MenuBarView));
            region.RegisterViewWithRegion("ButtonRegion", typeof(ButtonBarView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MenuBarView>("MenuBarView");
            containerRegistry.RegisterForNavigation<ButtonBarView>("ButtonBarView");
            containerRegistry.RegisterForNavigation<MainRegionView>("MainRegionView");
            containerRegistry.RegisterForNavigation<SecondView>("SecondView");

        }
    }
}
