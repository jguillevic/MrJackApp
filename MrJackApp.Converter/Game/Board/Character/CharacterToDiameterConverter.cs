using System;
using System.Globalization;
using System.Windows.Data;

namespace MrJackApp.Converter.Game.Board.Character
{
    public sealed class CharacterToDiameterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return CharacterConst.Diameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
