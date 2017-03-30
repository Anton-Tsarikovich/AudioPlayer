using System;
using System.Collections;
using System.Globalization;
using Xamarin.Forms;

namespace AudioPlayer
{
    class DataSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((IList)value).Count == 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
