using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBasicApplication.Library
{
    public class GlobalEvents : PubSubEvent<string>
    {
        private static readonly EventAggregator _eventAggregator;
        private static readonly GlobalEvents _event;

        static GlobalEvents()
        {
            _eventAggregator = new EventAggregator();
            _event = _eventAggregator.GetEvent<GlobalEvents>();
        }

        public static GlobalEvents Instance
        {
            get { return _event; }
        }
    }
    public static class GlobalVariables
    {
        static GlobalVariables()
        {
            RootPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MyBasicApplication";
        }

        public static string RootPath { get; private set; }
    }

}
