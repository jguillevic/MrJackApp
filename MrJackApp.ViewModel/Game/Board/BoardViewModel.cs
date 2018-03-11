using MrJackApp.DTO.Game.Board;
using MrJackApp.DTO.Game.Board.Character;
using MrJackApp.Service.Navigation;
using MrJackApp.ViewModel.Common.Command;
using MrJackApp.ViewModel.Common.Navigation;
using MrJackApp.ViewModel.Game.Board.Card;
using MrJackApp.ViewModel.Game.Board.Card.JackIdentity;
using MrJackApp.ViewModel.Game.Board.Card.JackVisibility;
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

        private bool _isJackVisibilityReady;
        public bool IsJackVisibilityReady
        {
            get { return _isJackVisibilityReady; }
            set { SetProperty(ref _isJackVisibilityReady, value); }
        }

        public ICommand StartGameCommand { get; private set; }
        public DelegateCommand InitializeCommand { get; private set; }

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
            IsJackVisibilityReady = false;
        }

        private void SetCommands()
        {
            InitializeCommand = new DelegateCommand(InitializeCommandExecute);
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

        private void InitializeCommandExecute()
        {           
            _isJack = _serviceClientManager.GameServiceClient.IsJack();

            Notifier.AllMessagesDisplayed += Sequence1MessagesDisplayed;
            Notifier.Notify("La partie commence");  
        }

        private void Sequence1MessagesDisplayed(object sender, System.EventArgs e)
        {
            Notifier.AllMessagesDisplayed -= Sequence1MessagesDisplayed;

            if (_isJack)
            {
                Notifier.AllMessagesDisplayed += JackSequence2MessagesDisplayed;

                Notifier.Notify("Vous êtes Jack");               
            }
            else
            {
                Notifier.AllMessagesDisplayed += InspectorSequence2MessagesDisplayed;

                Notifier.Notify("Vous êtes l'inspecteur");
            }
        }

        private void JackSequence2MessagesDisplayed(object sender, System.EventArgs e)
        {
            Notifier.AllMessagesDisplayed -= JackSequence2MessagesDisplayed;
            Notifier.AllMessagesDisplayed += JackSequence3MessagesDisplayed;

            Notifier.Notify("Voici votre identité");
            IsJackIdentityReady = true;
        }

        private void JackSequence3MessagesDisplayed(object sender, System.EventArgs e)
        {
            Notifier.AllMessagesDisplayed -= JackSequence3MessagesDisplayed;
            Notifier.AllMessagesDisplayed += JackSequence4MessagesDisplayed;

            Notifier.Notify("Vous êtes visible");
            IsJackVisibilityReady = true;
        }

        private void JackSequence4MessagesDisplayed(object sender, System.EventArgs e)
        {
            Notifier.AllMessagesDisplayed -= JackSequence4MessagesDisplayed;
            Notifier.AllMessagesDisplayed += JackSequence5MessagesDisplayed;

            Notifier.Notify("Ne vous faites pas attraper ou enfuyez vous !");
        }

        private void JackSequence5MessagesDisplayed(object sender, System.EventArgs e)
        {
            Notifier.AllMessagesDisplayed -= JackSequence5MessagesDisplayed;

            IsTurnSchedulerReady = true;
            IsTilesDisplayerReady = true;
            IsCharactersDisplayerReady = true;
        }

        private void InspectorSequence2MessagesDisplayed(object sender, System.EventArgs e)
        {
            Notifier.AllMessagesDisplayed -= InspectorSequence2MessagesDisplayed;
            Notifier.AllMessagesDisplayed += InspectorSequence3MessagesDisplayed;

            Notifier.Notify("Jack est visible");

            IsJackVisibilityReady = true;
        }

        private void InspectorSequence3MessagesDisplayed(object sender, System.EventArgs e)
        {
            Notifier.AllMessagesDisplayed -= InspectorSequence3MessagesDisplayed;
            Notifier.AllMessagesDisplayed += InspectorSequence4MessagesDisplayed;

            Notifier.Notify("Attrapez Jack !");
        }

        private void InspectorSequence4MessagesDisplayed(object sender, System.EventArgs e)
        {
            Notifier.AllMessagesDisplayed -= InspectorSequence4MessagesDisplayed;

            IsTurnSchedulerReady = true;
            IsTilesDisplayerReady = true;
            IsCharactersDisplayerReady = true;
        }

        

        

        private void StartGameMessagesDisplayed(object sender, System.EventArgs e)
        {
            Notifier.AllMessagesDisplayed -= StartGameMessagesDisplayed;

            IsTurnSchedulerReady = true;
            IsTilesDisplayerReady = true;
            IsCharactersDisplayerReady = true;           
        }
    }
}
