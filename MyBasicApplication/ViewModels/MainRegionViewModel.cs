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
using MyBasicApplication.Library.Models;
using System.Collections.ObjectModel;
using MyBasicApplication.Library;
using System.Data;
using MyBasicApplication.Converters;

namespace MyBasicApplication.ViewModels
{
    public class MainRegionViewModel : BindableBase
    {
        public DelegateCommand selectedCommand;
        public DelegateCommand clickedCommand;
        public ObservableCollection<PersonModel> People { get; set; }
        public string _dgHeaderDate;
        public string _dgHeaderTime;
        public string _dgHeaderContent;
        public string _dgHeaderValue;
        public string _dgHeaderType;
        public string _dgHeaderMessage;
        public DataTable _tableResult = new DataTable();

        public DataTable TableResult { get { return _tableResult; } set { SetProperty(ref _tableResult, value); RaisePropertyChanged("TableResult"); } }

        public string DgHeaderDate { get { return _dgHeaderDate; } set { SetProperty(ref _dgHeaderDate, value); } }
        public string DgHeaderTime { get { return _dgHeaderTime; } set { SetProperty(ref _dgHeaderTime, value); } }
        public string DgHeaderContent { get { return _dgHeaderContent; } set { SetProperty(ref _dgHeaderContent, value); } }
        public string DgHeaderValue { get { return _dgHeaderValue; } set { SetProperty(ref _dgHeaderValue, value); } }
        public string DgHeaderType { get { return _dgHeaderType; } set { SetProperty(ref _dgHeaderType, value); } }
        public string DgHeaderMessage { get { return _dgHeaderMessage; } set { SetProperty(ref _dgHeaderMessage, value); } }

        public MainRegionViewModel()
        {
            DataAccess da = new DataAccess();
            selectedCommand = new DelegateCommand(selectedCmd);
            clickedCommand = new DelegateCommand(clickedCmd);
            People = new ObservableCollection<PersonModel>(da.GetPeople());

            DataColumn date = new DataColumn(DgHeaderDate, typeof(string));
            DataColumn time = new DataColumn(DgHeaderTime, typeof(string));
            DataColumn content = new DataColumn(DgHeaderContent, typeof(string));
            DataColumn value = new DataColumn(DgHeaderValue, typeof(string));
            DataColumn type = new DataColumn(DgHeaderType, typeof(string));
            DataColumn message = new DataColumn(DgHeaderMessage, typeof(string));

            if (_tableResult.Columns.Count < 1)
            {
                _tableResult.Columns.Add(date);
                _tableResult.Columns.Add(time);
                _tableResult.Columns.Add(content);
                _tableResult.Columns.Add(value);
                _tableResult.Columns.Add(type);
                _tableResult.Columns.Add(message);
            }

            //DataGrid
            DgHeaderDate = INIFile.ReadValue(MyLanguage, "DataGrid", "dgHeaderDate");
            DgHeaderTime = INIFile.ReadValue(MyLanguage, "DataGrid", "dgHeaderTime");
            DgHeaderContent = INIFile.ReadValue(MyLanguage, "DataGrid", "dgHeaderContent");
            DgHeaderValue = INIFile.ReadValue(MyLanguage, "DataGrid", "dgHeaderValue");
            DgHeaderType = INIFile.ReadValue(MyLanguage, "DataGrid", "dgHeaderType");
            DgHeaderMessage = INIFile.ReadValue(MyLanguage, "DataGrid", "dgHeaderMessage");

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


