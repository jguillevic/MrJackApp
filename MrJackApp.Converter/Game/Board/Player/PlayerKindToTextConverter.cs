using MrJackApp.ViewModel.Game.Board.Player;
using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace MrJackApp.Converter.Game.Board.Player
{
    public sealed class PlayerKindToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var kind = (PlayerKind)value;

            var sb = new StringBuilder();
            sb.Append("Vous êtes ");

            switch (kind)
            {
                case PlayerKind.Undefined:
                    throw new ArgumentException();
                case PlayerKind.Jack:
                    sb.Append("Jack");
                    break;
                case PlayerKind.Inspector:
                    sb.Append("L'inspecteur");
                    break;
                default:
                    throw new ArgumentException();
            }

            return sb.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
