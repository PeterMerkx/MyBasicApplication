using System.ComponentModel;


namespace MyBasicApplication.Converters
{
    internal class Get_LogfileData :INotifyPropertyChanged
    {
 
        public string logDate { get; set; }
        public string logTime { get; set; }
        public string logContent { get; set; }
        public string logValue { get; set; }
        public string logType { get; set; }
        public string logMessage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}