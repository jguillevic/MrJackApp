using MrJackApp.ViewModel.Common;
using System;
using System.Globalization;
using System.Windows.Data;

namespace MrJackApp.Converter.Game.Board.Tile
{
    public sealed class TileCoordinateToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var coord = (Coordinate)value;

            return $"(X:{coord.X},Y:{coord.Y})";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
