using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MyForm
{
    public class NameOfObjectConverter : IValueConverter
    {
        #region Implementation of IValueConverter
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter as string;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    public class BoolToVisibilityConverter : IValueConverter
    {
        #region Implementation of IValueConverter
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = value is bool b && b;

            return val == true ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}