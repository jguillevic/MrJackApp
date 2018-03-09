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
using MrJackApp.WCFServiceClient.Game;
using System.Linq;
using System.Windows.Input;

namespace MrJackApp.ViewModel.Game.Board
{
    public sealed class BoardViewModel : NavigationViewModel
    {
        private bool _isJack;
        private ServiceClientManager _serviceClientManager;
        private CharacterViewModel _selectedCharacter;

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

        private bool _isTilesDisplayerReady;
        public bool IsTilesDisplayerReady
        {
            get { return _isTilesDisplayerReady; }
            set { SetProperty(ref _isTilesDisplayerReady, value); }
        }

        private bool _isCharactersDisplayerReady;
        public bool IsCharactersDisplayerReady
        {
            get { return _isCharactersDisplayerReady; }
            set { SetProperty(ref _isCharactersDisplayerReady, value); }
        }

        private bool _isJackIdentityReady;
        public bool IsJackIdentityReady
        {
            get { return _isJackIdentityReady; }
            set { SetProperty(ref _isJackIdentityReady, value); }
        }

        public ICommand StartGameCommand { get; private set; }

        public BoardViewModel(BoardDTO board, INavigationService navigationService, ServiceClientManager serviceClientManager) : base(navigationService)
        {     
            Map(board);
            SetFields(serviceClientManager);
            SetDefaultValues();
            SetCommands();
            SetEvents();
        }

        private void SetFields(ServiceClientManager serviceClientManager)
        {
            _serviceClientManager = serviceClientManager;
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
            IsTilesDisplayerReady = false;
            IsCharactersDisplayerReady = false;
            IsJackIdentityReady = false;
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

            _isJack = _serviceClientManager.GameServiceClient.IsJack();
            if (_isJack)
            {
                Notifier.Notify("Vous êtes Jack");
                Notifier.Notify("Voici votre identité");
                IsJackIdentityReady = true;
            }
            else
            {
                Notifier.Notify("Vous êtes l'inspecteur");
            }
        }

        private void StartGameMessagesDisplayed(object sender, System.EventArgs e)
        {
            IsTurnSchedulerReady = true;
            IsTilesDisplayerReady = true;
            IsCharactersDisplayerReady = true;
        }
    }
}
