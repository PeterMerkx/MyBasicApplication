using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyBasicApplication.Core;
using System.Windows;

namespace MyBasicApplication.ViewModels
{
    public class MainRegionViewModel : BindableBase
    {
        public DelegateCommand selectedCommand;
        public DelegateCommand clickedCommand;

        public MainRegionViewModel()
        {
            selectedCommand = new DelegateCommand(selectedCmd);
            clickedCommand = new DelegateCommand(clickedCmd);
        }
        public DelegateCommand SelectedCommand
        {
            get { return selectedCommand; }
        }
        public DelegateCommand ClickedCommand
        {
            get { return clickedCommand; }
        }
        private void selectedCmd()
        {
            MessageBox.Show("Selected button clicked", "Info");
        }
        private void clickedCmd()
        {
            MessageBox.Show("Click button clicked", "Info");
        }

    }

}


