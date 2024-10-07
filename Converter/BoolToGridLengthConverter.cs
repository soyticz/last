using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace wpf1
{
    public class BoolToGridLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isExpanded && parameter is string gridLengths)
            {
                var lengths = gridLengths.Split(',');
                return new GridLength(isExpanded ? double.Parse(lengths[0]) : double.Parse(lengths[1]));
            }
            return new GridLength(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
