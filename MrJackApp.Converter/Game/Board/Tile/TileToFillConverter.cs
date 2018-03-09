using MrJackApp.ViewModel.Game.Board.Tile;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
                    return new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/MrJackApp.Resource;component/Image/Game/Board/Tile/GasBurnerTileOn.png")));
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
                    return new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/MrJackApp.Resource;component/Image/Game/Board/Tile/ManholeTileOpen.png")));
                else
                    return new SolidColorBrush(Colors.Red);
            }
            else if (value is StreetTileViewModel)
            {
                return new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/MrJackApp.Resource;component/Image/Game/Board/Tile/StreetTile.png")));
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
