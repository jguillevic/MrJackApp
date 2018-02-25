using MrJackApp.Converter.Game.Board.Tile;
using MrJackApp.ViewModel.Common;
using System;
using System.Globalization;
using System.Windows.Data;

namespace MrJackApp.Converter.Game.Board.Character
{
    public sealed class CharacterXToXPosConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var coord = (CoordinateViewModel)value;

            return TileConst.Radius + coord.X * TileConst.Radius * 3f / 2f - CharacterConst.Radius;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
