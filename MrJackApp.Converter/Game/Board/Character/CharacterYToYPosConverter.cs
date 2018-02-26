using MrJackApp.Converter.Game.Board.Tile;
using MrJackApp.ViewModel.Common;
using System;
using System.Globalization;
using System.Windows.Data;

namespace MrJackApp.Converter.Game.Board.Character
{
    public sealed class CharacterYToYPosConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var coord = (Coordinate)value;

            double yOffset = 0;
            if (coord.X % 2 > 0)
                yOffset = Math.Sqrt(3) * TileConst.Radius / 2f;

            return yOffset + Math.Sqrt(3) * TileConst.Radius / 2f + coord.Y * Math.Sqrt(3) * TileConst.Radius - CharacterConst.Radius;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
