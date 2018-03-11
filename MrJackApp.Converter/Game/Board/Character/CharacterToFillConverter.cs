using MrJackApp.ViewModel.Game.Board.Character;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MrJackApp.Converter.Game.Board.Character
{
    public sealed class CharacterToFillConverter : IValueConverter
    {
        private static Brush _inspecteurLestradeBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/MrJackApp.Resource;component/Image/Game/Board/Character/InspecteurLestradeCharacter.png")));
        private static Brush _johnHWatsonBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/MrJackApp.Resource;component/Image/Game/Board/Character/JohnHWatsonCharacter.png")));
        private static Brush _missStealthyBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/MrJackApp.Resource;component/Image/Game/Board/Character/MissStealthyCharacter.png")));
        private static Brush _sergentGoodleyBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/MrJackApp.Resource;component/Image/Game/Board/Character/SergentGoodleyCharacter.png")));
        private static Brush _sherlockHolmesBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/MrJackApp.Resource;component/Image/Game/Board/Character/SherlockHolmesCharacter.png")));
        private static Brush _sirWilliamGullBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/MrJackApp.Resource;component/Image/Game/Board/Character/SirWilliamGullCharacter.png")));
        private static Brush _johnSmithBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/MrJackApp.Resource;component/Image/Game/Board/Character/JohnSmithCharacter.png")));
        private static Brush _jeremyBertBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/MrJackApp.Resource;component/Image/Game/Board/Character/JeremyBertCharacter.png")));

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is InspecteurLestradeViewModel)
                return _inspecteurLestradeBrush;
            else if (value is JeremyBertViewModel)
                return _jeremyBertBrush;
            else if (value is JohnSmithViewModel)
                return _johnSmithBrush;
            else if (value is JohnHWatsonViewModel)
                return _johnHWatsonBrush;
            else if (value is MissStealthyViewModel)
                return _missStealthyBrush;
            else if (value is SergentGoodleyViewModel)
                return _sergentGoodleyBrush;
            else if (value is SherlockHolmesViewModel)
                return _sherlockHolmesBrush;
            else if (value is SirWilliamGullViewModel)
                return _sirWilliamGullBrush;

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
