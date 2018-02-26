using MrJackApp.Converter.Game.Board.Tile;
using MrJackApp.ViewModel.Common;
using System;
using System.Globalization;
using System.Windows.Data;

namespace MrJackApp.Converter.Game.Board.Tile
{
    public sealed class TileXToXPosConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var coord = (Coordinate)value;

            return TileConst.Radius + coord.X * TileConst.Radius * 3f / 2f;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
