using MrJackApp.ViewModel.Common;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MrJackApp.Converter.Game.Board.Tile
{
    public class TilePosToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var coord = (Coordinate)value;

            var leftMargin = TileConst.Radius + coord.X * TileConst.Radius * 3f / 2f;

            double yOffset = 0;
            if (coord.X % 2 > 0)
                yOffset = Math.Sqrt(3) * TileConst.Radius / 2f;

            var topMargin = yOffset + Math.Sqrt(3) * TileConst.Radius / 2f + coord.Y * Math.Sqrt(3) * TileConst.Radius;

            return new Thickness(leftMargin, topMargin, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
