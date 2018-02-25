using MrJackApp.ViewModel.Game.Board.Character;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MrJackApp.Converter.Game.Board.Character
{
    public sealed class CharacterToFillConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is InspecteurLestradeViewModel)
                return new SolidColorBrush(Colors.DarkBlue);
            else if (value is JeremyBertViewModel)
                return new SolidColorBrush(Colors.Orange);
            else if (value is JohnSmithViewModel)
                return new SolidColorBrush(Colors.Yellow);
            else if (value is JohnHWatsonViewModel)
                return new SolidColorBrush(Colors.Maroon);
            else if (value is MissStealthyViewModel)
                return new SolidColorBrush(Colors.Green);
            else if (value is SergentGoodleyViewModel)
                return new SolidColorBrush(Colors.Black);
            else if (value is SherlockHolmesViewModel)
                return new SolidColorBrush(Colors.Red);
            else if (value is SirWilliamGullViewModel)
                return new SolidColorBrush(Colors.Purple);

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
