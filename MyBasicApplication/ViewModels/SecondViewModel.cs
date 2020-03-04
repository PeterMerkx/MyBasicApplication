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
    public class SecondViewModel : BindableBase
    {
        public DelegateCommand clickedCommand;
        public string _txtSecondView;
        public string _buttonBack;
        public string _buttonClick;
        private IRegionManager _regionManager;
        public ICommand NavigateToMainRegionViewCommand { get; private set; }

        public string TxtSecondView { get { return _txtSecondView; } set { SetProperty(ref _txtSecondView, value); } }
        public string ButtonBack { get { return _buttonBack; } set { SetProperty(ref _buttonBack, value); } }
        public string ButtonClick { get { return _buttonClick; } set { SetProperty(ref _buttonClick, value); } }

        public SecondViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateToMainRegionViewCommand = new DelegateCommand(() => NavigateTo("MainRegionView"));
            GlobalEvents.Instance.Subscribe(ProcessLanguage);
            SetItemsContent();
        }

        public void SetItemsContent()
        {
            TxtSecondView = "SecondView";
            ButtonBack = INIFile.ReadValue(MyLanguage, "Buttons", "cmdBack");

        }
        private void NavigateTo(string url)
        {
            _regionManager.RequestNavigate(Regions.MainRegion, url);
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
        private void ProcessLanguage(string language)
        {
            MyLanguage = language;
            SetItemsContent();
        }
        public DelegateCommand ClickedCommand
        {
            get { return clickedCommand; }
        }
        private void clickedCmd()
        {
            MessageBox.Show("Click button clicked", "Info");
        }

    }
}
