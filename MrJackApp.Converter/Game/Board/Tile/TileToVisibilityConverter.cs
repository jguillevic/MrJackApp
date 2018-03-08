using MrJackApp.ViewModel.Game.Board.Tile;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MrJackApp.Converter.Game.Board.Tile
{
    public sealed class TileToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is EmptyTileViewModel)
                return Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
