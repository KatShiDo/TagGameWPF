using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPF
{
    public class DateTimeToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int n = (int) value;
            return Math.Sign(n);
        }
     
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }  
    }
}