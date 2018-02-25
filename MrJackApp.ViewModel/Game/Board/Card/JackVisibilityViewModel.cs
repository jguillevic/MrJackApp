using MrJackApp.DTO.Game.Board.Card;
using MrJackApp.ViewModel.Common;

namespace MrJackApp.ViewModel.Game.Board.Card
{
    public sealed class JackVisibilityViewModel : BindableBase
    {
        private bool _isVisible;
        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }

        public JackVisibilityViewModel(JackVisibilityDTO jackVisibility) : base()
        {
            Map(jackVisibility);
        }

        private void Map(JackVisibilityDTO jackVisibility)
        {
            IsVisible = jackVisibility.IsVisibile;
        }
    }
}
