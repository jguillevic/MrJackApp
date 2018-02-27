using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MrJackApp.Converter.Game.Board.Turn
{
    public sealed class TurnToFillConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isCurrent = (bool)value;

            if (isCurrent)
                return new SolidColorBrush(Colors.Orange);
            else
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#468499"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
