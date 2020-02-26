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

namespace MyBasicApplication.ViewModels
{
    public class SecondViewModel : BindableBase
    {
        public string _txtSecondView;

        public string TxtSecondView { get { return _txtSecondView; } set { SetProperty(ref _txtSecondView, value); } }

        public SecondViewModel()
        {
            GlobalEvents.Instance.Subscribe(ProcessLanguage);
            SetItemsContent();
        }

        public void SetItemsContent()
        {
            TxtSecondView = INIFile.ReadValue(MyLanguage, "Labels", "txtSecondView");

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

    }
}
