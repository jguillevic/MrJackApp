using MrJackApp.Converter.Game.Board.Character;
using System.Windows.Controls;

namespace MrJackApp.View.Game.Board.Character
{
    /// <summary>
    /// Logique d'interaction pour CharacterView.xaml
    /// </summary>
    public partial class CharacterView : UserControl
    {
        public const double Diameter = CharacterConst.Diameter;

        public CharacterView()
        {
            InitializeComponent();
        }
    }
}
