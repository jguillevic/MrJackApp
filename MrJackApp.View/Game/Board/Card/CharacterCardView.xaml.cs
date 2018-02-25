using System.Windows;
using System.Windows.Controls;

namespace MrJackApp.View.Game.Board.Card
{
    /// <summary>
    /// Logique d'interaction pour CharacterCardView.xaml
    /// </summary>
    public partial class CharacterCardView : UserControl
    {
        public double CardWidth { get; private set; }
        public double CardHeight { get; private set; }
        public double CardRadius { get; private set; }
        public CornerRadius CardCornerRadius { get; private set; }
        public double CardBorderWidth { get; private set; }
        public double CardBorderHeight { get; private set; }
        public Thickness CardBorderThickness { get; private set; }
        public double CardInnerWidth { get; private set; }
        public double CardInnerHeight { get; private set; }
        public double GridWidth { get; private set; }
        public double GridHeight { get; private set; }

        public CharacterCardView()
        {
            InitializeComponent();

            CardWidth = 120f;
            CardBorderThickness = new Thickness(5);

            CardHeight = (5d / 3d) * CardWidth;
            CardRadius = CardWidth / 15f;
            CardCornerRadius = new CornerRadius(CardRadius);
            CardBorderWidth = CardWidth + 7;
            CardBorderHeight = CardHeight + 7;
            CardInnerWidth = CardWidth - 2 * CardRadius;
            CardInnerHeight = CardHeight - 2 * CardRadius;
            GridWidth = CardBorderWidth + 3;
            GridHeight = CardBorderHeight + 3;
        }


    }
}
