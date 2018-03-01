using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MrJackApp.Converter.Common.Command.Button
{
    public sealed class NavButCanExecuteToFillConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var canExecute = (bool)value;

            if (canExecute)
                return new SolidColorBrush(Colors.White);

            return new SolidColorBrush(Colors.SlateGray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
