using MrJackApp.DTO.Game.Board;
using MrJackApp.DTO.Game.Board.Character;
using MrJackApp.Service.Navigation;
using MrJackApp.ViewModel.Common.Command;
using MrJackApp.ViewModel.Common.Navigation;
using MrJackApp.ViewModel.Game.Board.Card;
using MrJackApp.ViewModel.Game.Board.Character;
using MrJackApp.ViewModel.Game.Board.Notifier;
using MrJackApp.ViewModel.Game.Board.Tile;
using MrJackApp.ViewModel.Game.Board.Turn;
using System.Linq;
using System.Windows.Input;

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

        private bool _isTurnSchedulerReady;
        public bool IsTurnSchedulerReady
        {
            get { return _isTurnSchedulerReady; }
            set { SetProperty(ref _isTurnSchedulerReady, value); }
        }

        public ICommand StartGameCommand { get; private set; }

        public BoardViewModel(BoardDTO board, INavigationService navigationService) : base(navigationService)
        {
            Map(board);
            SetDefaultValues();
            SetCommands();
            SetEvents();
        }

        private void Map(BoardDTO board)
        {
            TilesDisplayer = new TilesDisplayerViewModel(board.Tiles);
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
            TilesDisplayer.TileSelected += ManageTileSelection;
            CharacterCardsDisplayer.CardSelected += CharacterCardsDisplayerCardSelected;
            AlibiCardsDisplayer.CardSelected += AlibiCardsDisplayerCardSelected;
        }

        private void SetDefaultValues()
        {
            IsTurnSchedulerReady = false;
        }

        private void SetCommands()
        {
            StartGameCommand = new DelegateCommand(StartGameCommandExecute);
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

        private void StartGameCommandExecute()
        {
            Notifier.AllMessagesDisplayed += StartGameMessagesDisplayed;
            Notifier.Notify("La partie commence");
            Notifier.Notify("Vous êtes Jack");
            Notifier.Notify("Voici votre identité");
        }

        private void StartGameMessagesDisplayed(object sender, System.EventArgs e)
        {
            IsTurnSchedulerReady = true;
        }
    }
}
