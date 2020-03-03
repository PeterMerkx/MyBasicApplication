using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WorkingWithDatabaseMVVM.Views;
using Prism.Autofac;
using Autofac;
using Unity;


namespace MyBasicApplication
{
    public class Bootstrapper : UnityBootstrapper
    {
        public override void Run(bool runWithDefaultConfiguration)
        {
            base.Run(runWithDefaultConfiguration);
        }
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void InitializeShell()
        {

            Application.Current.MainWindow.Show();
        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterTypeForNavigation<MainRegionView>("MainRegionView");
            Container.RegisterTypeForNavigation<MenuBarView>("MenuBarView");
            Container.RegisterTypeForNavigation<ButtonBarView>("ButtonBarView");

        }
    }
}
