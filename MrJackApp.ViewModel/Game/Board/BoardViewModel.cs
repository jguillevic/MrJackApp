using MrJackApp.DTO.Game.Board;
using MrJackApp.DTO.Game.Board.Character;
using MrJackApp.Service.Navigation;
using MrJackApp.ViewModel.Common.Navigation;
using MrJackApp.ViewModel.Game.Board.Card;
using MrJackApp.ViewModel.Game.Board.Character;
using MrJackApp.ViewModel.Game.Board.Notifier;
using MrJackApp.ViewModel.Game.Board.Tile;
using MrJackApp.ViewModel.Game.Board.Turn;
using System.Linq;

namespace MrJackApp.ViewModel.Game.Board
{
    public sealed class BoardViewModel : NavigationViewModel
    {
        public CharacterViewModel _selectedCharacter;

        public TilesDisplayerViewModel TilesDisplayer { get; private set; }
        public CharactersDisplayerViewModel CharactersDisplayer { get; private set; }
        public AlibiCardsDisplayerViewModel AlibiCardsDisplayer { get; } = new AlibiCardsDisplayerViewModel();
        public CharacterCardsDisplayerViewModel CharacterCardsDisplayer { get; } = new CharacterCardsDisplayerViewModel();
        public JackVisibilityViewModel JackVisibility { get; private set; }
        public JackIdentityViewModel JackIdentity { get; private set; }
        public TurnSchedulerViewModel TurnScheduler { get; private set; }
        public NotifierViewModel Notifier { get; } = new NotifierViewModel();

        public BoardViewModel(BoardDTO board, INavigationService navigationService) : base(navigationService)
        {
            Map(board);

            SetEvents();
        }

        private void Map(BoardDTO board)
        {
            TilesDisplayer = new TilesDisplayerViewModel(board.Tiles);
            TilesDisplayer.TileSelected += ManageTileSelection;
            CharactersDisplayer = new CharactersDisplayerViewModel(board.Characters);
            JackVisibility = new JackVisibilityViewModel(board.JackVisibility);
            JackIdentity = new JackIdentityViewModel(board.JackIdentity);
            TurnScheduler = new TurnSchedulerViewModel(board.TurnScheduler);
        }

        private void ManageTileSelection(object sender, TileSelectedEventArgs e)
        {
            if (_selectedCharacter != null)
            {
                var tile = e.Tile;
                if (tile.CanGoOn)
                {
                    var coord = tile.Coordinate;
                    _selectedCharacter.MoveTo(coord.X, coord.Y);
                }
            }
        }

        private void SetEvents()
        {
            CharacterCardsDisplayer.CardSelected += CharacterCardsDisplayerCardSelected;
            AlibiCardsDisplayer.CardSelected += AlibiCardsDisplayerCardSelected;
        }

        private void CharacterCardsDisplayerCardSelected(object sender, CardSelectedEventArgs e)
        {
            var card = e.Card;
            if (card.IsSelected)
                _selectedCharacter = CharactersDisplayer.Characters.First(item => item.Id == card.CharacterId);
            else
                _selectedCharacter = null;
        }

        private void AlibiCardsDisplayerCardSelected(object sender, CardSelectedEventArgs e)
        {

        }

        private void MapCharactersDisplayer(CharacterDTO[] characters)
        {

        }
    }
}
