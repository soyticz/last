using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace wpf1
{
    public abstract class BooleanToValueConverter<T> : IValueConverter
    {
        public abstract T TrueValue { get; }
        public abstract T FalseValue { get; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value is bool isTrue)
                {
                    return isTrue ? TrueValue : FalseValue;
                }
                return FalseValue;
            }
            catch (System.Exception e)
            {
                MessageBox.Show($"BooleanToConverterClass: {e}");
                return FalseValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
