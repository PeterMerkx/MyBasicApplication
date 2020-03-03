using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBasicApplication.Core
{
    public class MessageItem : ObservableObject
    {
        private string _date;
        private string _time;
        private string _content;
        private string _value;
        private string _type;
        private string _message;

        public MessageItem()
        {

        }

        public MessageItem(string date, string time, string content, string value, string type, string message)
        {
            _date = date;
            _time = time;
            _content = content;
            _value = value;
            _type = type;
            _message = message;
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; RaisePropertyChangedEvent("Date"); }
        }
        public string Time
        {
            get { return _time; }
            set { _time = value; RaisePropertyChangedEvent("Time"); }
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; RaisePropertyChangedEvent("Content"); }
        }
        public string Value
        {
            get { return _value; }
            set { _value = value; RaisePropertyChangedEvent("Value"); }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; RaisePropertyChangedEvent("Type"); }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; RaisePropertyChangedEvent("Message"); }
        }


    }
}
