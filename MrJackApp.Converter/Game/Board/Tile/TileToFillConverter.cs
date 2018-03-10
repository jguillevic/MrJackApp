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
        private static Brush _gasBurnerTileOnBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/MrJackApp.Resource;component/Image/Game/Board/Tile/GasBurnerTileOn.png")));
        private static Brush _gasBurnerTileOffBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/MrJackApp.Resource;component/Image/Game/Board/Tile/GasBurnerTileOff.png")));
        private static Brush _streetTileBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/MrJackApp.Resource;component/Image/Game/Board/Tile/StreetTile.png")));
        private static Brush _manholeTileOpenBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/MrJackApp.Resource;component/Image/Game/Board/Tile/ManholeTileOpen.png")));
        private static Brush _manholeTileCloseBrush = new SolidColorBrush(Colors.Red);
        private static Brush _houseTileBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/MrJackApp.Resource;component/Image/Game/Board/Tile/HouseTile.png")));
        private static Brush _exitTileBlockedBrush = new SolidColorBrush(Colors.DarkBlue);
        private static Brush _exitTileNotBlockedBrush = new SolidColorBrush(Colors.LightBlue);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ExitTileViewModel)
            {
                if (((ExitTileViewModel)value).IsBlocked)
                    return _exitTileBlockedBrush;
                else
                    return _exitTileNotBlockedBrush;
            }
            else if (value is GasBurnerTileViewModel)
            {
                if (((GasBurnerTileViewModel)value).IsOn)
                    return _gasBurnerTileOnBrush;
                else
                    return _gasBurnerTileOffBrush;
            }
            else if (value is HouseTileViewModel)
            {
                return _houseTileBrush;
            }
            else if (value is ManholeTileViewModel)
            {
                if (((ManholeTileViewModel)value).IsOpen)
                    return _manholeTileOpenBrush;
                else
                    return _manholeTileCloseBrush;
            }
            else if (value is StreetTileViewModel)
            {
                return _streetTileBrush;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
