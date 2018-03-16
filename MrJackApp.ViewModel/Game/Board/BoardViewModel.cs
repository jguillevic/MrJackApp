using MrJackApp.DTO.Game;
using MrJackApp.DTO.Game.Board.Character;
using MrJackApp.Service.Navigation;
using MrJackApp.ViewModel.Common.Command;
using MrJackApp.ViewModel.Common.Navigation;
using MrJackApp.ViewModel.Game.Board.Card;
using MrJackApp.ViewModel.Game.Board.Card.JackIdentity;
using MrJackApp.ViewModel.Game.Board.Card.JackVisibility;
using MrJackApp.ViewModel.Game.Board.Character;
using MrJackApp.ViewModel.Game.Board.Notifier;
using MrJackApp.ViewModel.Game.Board.Player;
using MrJackApp.ViewModel.Game.Board.Tile;
using MrJackApp.ViewModel.Game.Board.Turn;
using MrJackApp.ViewModel.Game.Board.Visibility;
using MrJackApp.WCFServiceClient.Game;
using System.Linq;
using System.Windows.Input;

namespace MrJackApp.ViewModel.Game.Board
{
    public sealed class BoardViewModel : NavigationViewModel
    {
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
        public PlayerDisplayerViewModel PlayerDisplayer { get; private set; }
        public VisibilityManagerViewModel VisibilityManager { get; } = new VisibilityManagerViewModel();

        public ICommand InitializeCommand { get; private set; }

        public BoardViewModel(GameDTO game, INavigationService navigationService, ServiceClientManager serviceClientManager) : base(navigationService)
        {     
            Map(game);
            SetFields(serviceClientManager);
            SetCommands();
            SetEvents();
        }

        private void SetFields(ServiceClientManager serviceClientManager)
        {
            _serviceClientManager = serviceClientManager;
        }

        private void Map(GameDTO game)
        {
            var board = game.Board;
            TilesDisplayer = new TilesDisplayerViewModel(board.Tiles);
            CharactersDisplayer = new CharactersDisplayerViewModel(board.Characters);
            JackVisibility = new JackVisibilityViewModel(board.JackVisibility);
            JackIdentity = new JackIdentityViewModel(board.JackIdentity);
            TurnScheduler = new TurnSchedulerViewModel(board.TurnScheduler);

            PlayerDisplayer = new PlayerDisplayerViewModel(game.Player);
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
            Notifier.AllMessagesDisplayed += Sequence1MessagesDisplayed;
            Notifier.Notify("La partie commence");  
        }

        private void Sequence1MessagesDisplayed(object sender, System.EventArgs e)
        {
            Notifier.AllMessagesDisplayed -= Sequence1MessagesDisplayed;

            if (PlayerDisplayer.IsJack)
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
            VisibilityManager.IsJackIdentityDisplayable = true;
        }

        private void JackSequence3MessagesDisplayed(object sender, System.EventArgs e)
        {
            Notifier.AllMessagesDisplayed -= JackSequence3MessagesDisplayed;
            Notifier.AllMessagesDisplayed += JackSequence4MessagesDisplayed;

            Notifier.Notify("Vous êtes visible");
            VisibilityManager.IsJackVisibilityDisplayable = true;
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

            VisibilityManager.IsTurnSchedulerDisplayable = true;
            VisibilityManager.IsTilesDisplayerDisplayable = true;
            VisibilityManager.IsCharactersDisplayerDisplayable = true;
        }

        private void InspectorSequence2MessagesDisplayed(object sender, System.EventArgs e)
        {
            Notifier.AllMessagesDisplayed -= InspectorSequence2MessagesDisplayed;
            Notifier.AllMessagesDisplayed += InspectorSequence3MessagesDisplayed;

            Notifier.Notify("Jack est visible");

            VisibilityManager.IsJackVisibilityDisplayable = true;
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

            VisibilityManager.IsTurnSchedulerDisplayable = true;
            VisibilityManager.IsTilesDisplayerDisplayable = true;
            VisibilityManager.IsCharactersDisplayerDisplayable = true;
        }
    }
}
