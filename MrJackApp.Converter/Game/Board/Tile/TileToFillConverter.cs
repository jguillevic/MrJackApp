using MrJackApp.ViewModel.Game.Board.Tile;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MrJackApp.Converter.Game.Board.Tile
{
    public sealed class TileToFillConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ExitTileViewModel)
            {
                if (((ExitTileViewModel)value).IsBlocked)
                    return new SolidColorBrush(Colors.LightBlue);
                else
                    return new SolidColorBrush(Colors.DarkBlue);
            }
            else if (value is GasBurnerTileViewModel)
            {
                if (((GasBurnerTileViewModel)value).IsOn)
                    return new SolidColorBrush(Colors.Yellow);
                else
                    return new SolidColorBrush(Colors.LightYellow);
            }
            else if (value is HouseTileViewModel)
            {
                return new SolidColorBrush(Colors.Black);
            }
            else if (value is ManholeTileViewModel)
            {
                if (((ManholeTileViewModel)value).IsOpen)
                    return new SolidColorBrush(Colors.Green);
                else
                    return new SolidColorBrush(Colors.Red);
            }
            else if (value is StreetTileViewModel)
            {
                return new SolidColorBrush(Colors.LightGray);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
