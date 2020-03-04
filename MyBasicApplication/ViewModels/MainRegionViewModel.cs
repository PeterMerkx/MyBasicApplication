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
using System.Collections.ObjectModel;
using MyBasicApplication.Library;
using System.Data;
using MyBasicApplication.Converters;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Regions;

namespace MyBasicApplication.ViewModels
{
    public class MainRegionViewModel : BindableBase
    {
        public DelegateCommand selectedCommand;
        public string _buttonSelect;
        public string _buttonClick;
        public string _txtMainArea;
        private IRegionManager _regionManager;
        public ICommand NavigateToSecondViewCommand { get; private set; }

        public string ButtonSelect { get { return _buttonSelect; } set { SetProperty(ref _buttonSelect, value); } }
        public string ButtonClick { get { return _buttonClick; } set { SetProperty(ref _buttonClick, value); } }
        public string TxtMainArea { get { return _txtMainArea; } set { SetProperty(ref _txtMainArea, value); } }
        public MainRegionViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            selectedCommand = new DelegateCommand(selectedCmd);
            NavigateToSecondViewCommand = new DelegateCommand(() => NavigateTo("SecondView"));
            GlobalEvents.Instance.Subscribe(ProcessLanguage);
            SetItemsContent();
        }
        public string MyLanguage
        {
            get { return Properties.Settings.Default.applanguage; }
            set
            {
                Properties.Settings.Default.applanguage = value;
                Properties.Settings.Default.Save();
            }
        }
        public void SetItemsContent()
        {
            //buttonlabels
            ButtonSelect = INIFile.ReadValue(MyLanguage, "Buttons", "cmdSelect");
            ButtonClick = INIFile.ReadValue(MyLanguage, "Buttons", "cmdClick");
            TxtMainArea = "MainArea";

        }
        private void NavigateTo(string url)
        {
            _regionManager.RequestNavigate(Regions.MainRegion, url);
        }

        public DelegateCommand SelectedCommand
        {
            get { return selectedCommand; }
        }


        private void selectedCmd()
        {
            MessageBox.Show("Selected button clicked", "Info");
        }
        private void clickedCmd()
        {
            MessageBox.Show("Click button clicked", "Info");
        }
        private void ProcessLanguage(string language)
        {
            MyLanguage = language;
            SetItemsContent();
        }

    }

}


