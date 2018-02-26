using MrJackApp.DTO.Game.Board;
using MrJackApp.DTO.Game.Board.Tile;
using MrJackApp.ViewModel.Game.Board.Card;
using MrJackApp.ViewModel.Game.Board.Character;
using MrJackApp.ViewModel.Common;
using MrJackApp.ViewModel.Game.Board.Tile;
using MrJackApp.ViewModel.Game.Board.Turn;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using MrJackApp.ViewModel.Common.Navigation;
using MrJackApp.DTO.Game.Board.Character;

namespace MrJackApp.ViewModel.Game.Board
{
    public sealed class BoardViewModel : NavigationViewModel
    {
        public CharacterViewModel _selectedCharacter;

        public ObservableCollection<TileViewModel> Tiles { get; private set; } = new ObservableCollection<TileViewModel>();
        public ObservableCollection<CharacterViewModel> Characters { get; private set; } = new ObservableCollection<CharacterViewModel>();
        public AlibiCardsDisplayerViewModel AlibiCardsDisplayer { get; private set; } = new AlibiCardsDisplayerViewModel();
        public CharacterCardsDisplayerViewModel CharacterCardsDisplayer { get; private set; } = new CharacterCardsDisplayerViewModel();
        public JackVisibilityViewModel JackVisibility { get; private set; }
        public JackIdentityViewModel JackIdentity { get; private set; }
        public TurnSchedulerViewModel TurnScheduler { get; private set; }

        public BoardViewModel(BoardDTO board, INavigationService navigationService) : base(navigationService)
        {
            Map(board);

            SetEvents();
        }

        private void Map(BoardDTO board)
        {
            MapTiles(board);
            MapCharacters(board);
            MapJackVisibility(board);
            MapJackIdentity(board);
            MapTurnScheduler(board);
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
                _selectedCharacter = Characters.First(item => item.Id == card.CharacterId);
            else
                _selectedCharacter = null;
        }

        private void AlibiCardsDisplayerCardSelected(object sender, CardSelectedEventArgs e)
        {

        }

        private void MapTurnScheduler(BoardDTO board)
        {
            TurnScheduler = new TurnSchedulerViewModel(board.TurnScheduler);
        }

        private void MapJackIdentity(BoardDTO board)
        {
            JackIdentity = new JackIdentityViewModel(board.JackIdentity);
        }

        private void MapJackVisibility(BoardDTO board)
        {
            JackVisibility = new JackVisibilityViewModel(board.JackVisibility);
        }

        private void MapCharacters(BoardDTO board)
        {
            for (int i = 0; i < board.Characters.Length; i++)
            {
                CharacterViewModel charViewModel = null;
                var character = board.Characters[i];

                switch (character.Kind)
                {
                    case CharacterKind.SherlockHolmes:
                        charViewModel = new SherlockHolmesViewModel(character);
                        break;
                    case CharacterKind.JohnHWatson:
                        charViewModel = new JohnHWatsonViewModel(character);
                        break;
                    case CharacterKind.JohnSmith:
                        charViewModel = new JohnSmithViewModel(character);
                        break;
                    case CharacterKind.InspecteurLestrade:
                        charViewModel = new InspecteurLestradeViewModel(character);
                        break;
                    case CharacterKind.MissStealthy:
                        charViewModel = new MissStealthyViewModel(character);
                        break;
                    case CharacterKind.SergentGoodley:
                        charViewModel = new SergentGoodleyViewModel(character);
                        break;
                    case CharacterKind.SirWilliamGull:
                        charViewModel = new SirWilliamGullViewModel(character);
                        break;
                    case CharacterKind.JeremyBert:
                        charViewModel = new JeremyBertViewModel(character);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                Characters.Add(charViewModel);
            }
        }

        private void MapTiles(BoardDTO board)
        {
            for (int i = 0; i < board.Tiles.Length; i++)
            {
                for (int j = 0; j < board.Tiles[i].Length; j++)
                {
                    TileViewModel tileViewModel = null;
                    var tile = board.Tiles[i][j];

                    if (tile is ExitTileDTO)
                        tileViewModel = new ExitTileViewModel(tile);
                    else if (tile is GasBurnerTileDTO)
                        tileViewModel = new GasBurnerTileViewModel(tile);
                    else if (tile is HouseTileDTO)
                        tileViewModel = new HouseTileViewModel(tile);
                    else if (tile is ManholeTileDTO)
                        tileViewModel = new ManholeTileViewModel(tile);
                    else if (tile is StreetTileDTO)
                        tileViewModel = new StreetTileViewModel(tile);
                    else if (tile is EmptyTileDTO)
                        tileViewModel = new EmptyTileViewModel(tile);
                    else
                        throw new NotImplementedException();

                    tileViewModel.Selected += ManageTileViewModelSelection;

                    Tiles.Add(tileViewModel);
                }
            }
        }

        private void ManageTileViewModelSelection(object sender, EventArgs e)
        {
            if (_selectedCharacter != null)
            {
                var tile = (TileViewModel)sender;
                if (tile.CanGoOn)
                {
                    var coord = tile.Coordinate;
                    _selectedCharacter.MoveTo(coord.X, coord.Y);
                }
            }
        }
    }
}
