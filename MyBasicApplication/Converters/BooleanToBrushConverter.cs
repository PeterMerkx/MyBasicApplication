using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MyBasicApplication.Converters
{
    class BooleanToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? state = value as bool?;
            if (state == null)
                return Brushes.Gray;

            if (state == true)
                return Brushes.LimeGreen;

            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
