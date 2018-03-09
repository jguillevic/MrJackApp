using MrJackApp.DTO.Game.Board;
using MrJackApp.DTO.Game.Board.Card;
using MrJackApp.DTO.Game.Board.Character;
using MrJackApp.DTO.Game.Board.Tile;
using MrJackApp.Engine.Game.Board.Card;
using MrJackApp.Engine.Game.Board.Character;
using MrJackApp.Engine.Game.Board.Tile;
using MrJackApp.Engine.Game.Board.Turn;

namespace MrJackApp.Engine.Game.Board
{
    public sealed class Board
    {
        public Tile.Tile[,] Tiles { get; private set; } = new Tile.Tile[13, 9];
        public Character.Character[] Characters { get; private set; } = new Character.Character[8];
        public TurnScheduler TurnScheduler { get; private set; } = new TurnScheduler();
        public JackVisibility JackVisibility { get; set; }
        public CharacterDeck CharacterDeck { get; private set; } = new CharacterDeck();
        public AlibiDeck AlibiDeck { get; private set; } = new AlibiDeck();

        public void Init()
        {
            Generate();

            JackVisibility = JackVisibility.Light;

            TurnScheduler.Init();

            CharacterDeck.Init();
            CharacterDeck.Shuffle();

            AlibiDeck.Init();
            AlibiDeck.Shuffle();
        }

        public void Generate()
        {
            GenerateLines();

            AddCharacters();
        }

        private void GenerateLines()
        {
            GenerateLine0();
            GenerateLine1();
            GenerateLine2();
            GenerateLine3();
            GenerateLine4();
            GenerateLine5();
            GenerateLine6();
            GenerateLine7();
            GenerateLine8();
            GenerateLine9();
            GenerateLine10();
            GenerateLine11();
            GenerateLine12();
        }

        private void GenerateLine0()
        {
            Tiles[0, 0] = new EmptyTile { X = 0, Y = 0 };
            Tiles[0, 1] = new ExitTile { X = 0, Y = 1, IsBlocked = false };
            Tiles[0, 2] = new EmptyTile { X = 0, Y = 2 };
            Tiles[0, 3] = new StreetTile { X = 0, Y = 3 };
            Tiles[0, 4] = new StreetTile { X = 0, Y = 4 };
            Tiles[0, 5] = new StreetTile { X = 0, Y = 5 };
            Tiles[0, 6] = new StreetTile { X = 0, Y = 6 };
            Tiles[0, 7] = new StreetTile { X = 0, Y = 7 };
            Tiles[0, 8] = new ExitTile { X = 0, Y = 8, IsBlocked = true };
        }

        private void GenerateLine1()
        {
            Tiles[1, 0] = new EmptyTile { X = 1, Y = 0 };
            Tiles[1, 1] = new StreetTile { X = 1, Y = 1 };
            Tiles[1, 2] = new ManholeTile { X = 1, Y = 2, IsOpen = true };
            Tiles[1, 3] = new HouseTile { X = 1, Y = 3 };
            Tiles[1, 4] = new HouseTile { X = 1, Y = 4 };
            Tiles[1, 5] = new StreetTile { X = 1, Y = 5 };
            Tiles[1, 6] = new GasBurnerTile { X = 1, Y = 6, IsOn = true };
            Tiles[1, 7] = new ManholeTile { X = 1, Y = 7, IsOpen = false };
            Tiles[1, 8] = new EmptyTile { X = 1, Y = 8 };
        }

        private void GenerateLine2()
        {
            Tiles[2, 0] = new EmptyTile { X = 2, Y = 0 };
            Tiles[2, 1] = new EmptyTile { X = 2, Y = 1 };
            Tiles[2, 2] = new GasBurnerTile { X = 2, Y = 2, IsOn = true };
            Tiles[2, 3] = new StreetTile { X = 2, Y = 3 };
            Tiles[2, 4] = new HouseTile { X = 2, Y = 4 };
            Tiles[2, 5] = new ManholeTile { X = 2, Y = 5, IsOpen = true };
            Tiles[2, 6] = new StreetTile { X = 2, Y = 6 };
            Tiles[2, 7] = new StreetTile { X = 2, Y = 7 };
            Tiles[2, 8] = new EmptyTile { X = 2, Y = 8 };
        }

        private void GenerateLine3()
        {
            Tiles[3, 0] = new EmptyTile { X = 3, Y = 0 };
            Tiles[3, 1] = new HouseTile { X = 3, Y = 1 };
            Tiles[3, 2] = new StreetTile { X = 3, Y = 2 };
            Tiles[3, 3] = new HouseTile { X = 3, Y = 3 };
            Tiles[3, 4] = new StreetTile { X = 3, Y = 4 };
            Tiles[3, 5] = new HouseTile { X = 3, Y = 5 };
            Tiles[3, 6] = new StreetTile { X = 3, Y = 6 };
            Tiles[3, 7] = new EmptyTile { X = 3, Y = 7 };
            Tiles[3, 8] = new EmptyTile { X = 3, Y = 8 };
        }

        private void GenerateLine4()
        {
            Tiles[4, 0] = new EmptyTile { X = 4, Y = 0 };
            Tiles[4, 1] = new StreetTile { X = 4, Y = 1 };
            Tiles[4, 2] = new StreetTile { X = 4, Y = 2 };
            Tiles[4, 3] = new StreetTile { X = 4, Y = 3 };
            Tiles[4, 4] = new StreetTile { X = 4, Y = 4 };
            Tiles[4, 5] = new StreetTile { X = 4, Y = 5 };
            Tiles[4, 6] = new StreetTile { X = 4, Y = 6 };
            Tiles[4, 7] = new StreetTile { X = 4, Y = 7 };
            Tiles[4, 8] = new EmptyTile { X = 4, Y = 8 };
        }

        private void GenerateLine5()
        {
            Tiles[5, 0] = new ManholeTile { X = 5, Y = 0, IsOpen = true };
            Tiles[5, 1] = new GasBurnerTile { X = 5, Y = 1, IsOn = false };
            Tiles[5, 2] = new HouseTile { X = 5, Y = 2 };
            Tiles[5, 3] = new StreetTile { X = 5, Y = 3 };
            Tiles[5, 4] = new HouseTile { X = 5, Y = 4 };
            Tiles[5, 5] = new GasBurnerTile { X = 5, Y = 5, IsOn = true };
            Tiles[5, 6] = new HouseTile { X = 5, Y = 6 };
            Tiles[5, 7] = new StreetTile { X = 5, Y = 7 };
            Tiles[5, 8] = new EmptyTile { X = 5, Y = 8 };
        }

        private void GenerateLine6()
        {
            Tiles[6, 0] = new EmptyTile { X = 6, Y = 0 };
            Tiles[6, 1] = new StreetTile { X = 6, Y = 1 };
            Tiles[6, 2] = new StreetTile { X = 6, Y = 2 };
            Tiles[6, 3] = new StreetTile { X = 6, Y = 3 };
            Tiles[6, 4] = new StreetTile { X = 6, Y = 4 };
            Tiles[6, 5] = new ManholeTile { X = 6, Y = 5, IsOpen = true };
            Tiles[6, 6] = new StreetTile { X = 6, Y = 6 };
            Tiles[6, 7] = new StreetTile { X = 6, Y = 7 };
            Tiles[6, 8] = new StreetTile { X = 6, Y = 8 };
        }

        private void GenerateLine7()
        {
            Tiles[7, 0] = new EmptyTile { X = 7, Y = 0 };
            Tiles[7, 1] = new StreetTile { X = 7, Y = 1 };
            Tiles[7, 2] = new HouseTile { X = 7, Y = 2 };
            Tiles[7, 3] = new GasBurnerTile { X = 7, Y = 3, IsOn = true };
            Tiles[7, 4] = new HouseTile { X = 7, Y = 4 };
            Tiles[7, 5] = new StreetTile { X = 7, Y = 5 };
            Tiles[7, 6] = new HouseTile { X = 7, Y = 6 };
            Tiles[7, 7] = new GasBurnerTile { X = 7, Y = 7, IsOn = false };
            Tiles[7, 8] = new ManholeTile { X = 7, Y = 8, IsOpen = true };
        }

        private void GenerateLine8()
        {
            Tiles[8, 0] = new EmptyTile { X = 8, Y = 0 };
            Tiles[8, 1] = new EmptyTile { X = 8, Y = 1 };
            Tiles[8, 2] = new StreetTile { X = 8, Y = 2 };
            Tiles[8, 3] = new StreetTile { X = 8, Y = 3 };
            Tiles[8, 4] = new StreetTile { X = 8, Y = 4 };
            Tiles[8, 5] = new StreetTile { X = 8, Y = 5 };
            Tiles[8, 6] = new StreetTile { X = 8, Y = 6 };
            Tiles[8, 7] = new StreetTile { X = 8, Y = 7 };
            Tiles[8, 8] = new StreetTile { X = 8, Y = 8 };
        }

        private void GenerateLine9()
        {
            Tiles[9, 0] = new EmptyTile { X = 9, Y = 0 };
            Tiles[9, 1] = new EmptyTile { X = 9, Y = 1 };
            Tiles[9, 2] = new StreetTile { X = 9, Y = 2 };
            Tiles[9, 3] = new HouseTile { X = 9, Y = 3 };
            Tiles[9, 4] = new StreetTile { X = 9, Y = 4 };
            Tiles[9, 5] = new HouseTile { X = 9, Y = 5 };
            Tiles[9, 6] = new StreetTile { X = 9, Y = 6 };
            Tiles[9, 7] = new HouseTile { X = 9, Y = 7 };
            Tiles[9, 8] = new EmptyTile { X = 9, Y = 8 };
        }

        private void GenerateLine10()
        {
            Tiles[10, 0] = new EmptyTile { X = 10, Y = 0 };
            Tiles[10, 1] = new EmptyTile { X = 10, Y = 1 };
            Tiles[10, 2] = new StreetTile { X = 10, Y = 2 };
            Tiles[10, 3] = new StreetTile { X = 10, Y = 3 };
            Tiles[10, 4] = new ManholeTile { X = 10, Y = 4, IsOpen = true };
            Tiles[10, 5] = new HouseTile { X = 10, Y = 5 };
            Tiles[10, 6] = new StreetTile { X = 10, Y = 6 };
            Tiles[10, 7] = new GasBurnerTile { X = 10, Y = 7, IsOn = true };
            Tiles[10, 8] = new EmptyTile { X = 10, Y = 8 };
        }

        private void GenerateLine11()
        {
            Tiles[11, 0] = new EmptyTile { X = 11, Y = 0 };
            Tiles[11, 1] = new ManholeTile { X = 11, Y = 1, IsOpen = false };
            Tiles[11, 2] = new GasBurnerTile { X = 11, Y = 2, IsOn = true };
            Tiles[11, 3] = new StreetTile { X = 11, Y = 3 };
            Tiles[11, 4] = new HouseTile { X = 11, Y = 4 };
            Tiles[11, 5] = new HouseTile { X = 11, Y = 5 };
            Tiles[11, 6] = new ManholeTile { X = 11, Y = 6, IsOpen = true };
            Tiles[11, 7] = new StreetTile { X = 11, Y = 7 };
            Tiles[11, 8] = new EmptyTile { X = 11, Y = 8 };
        }

        private void GenerateLine12()
        {
            Tiles[12, 0] = new EmptyTile { X = 12, Y = 0 };
            Tiles[12, 1] = new ExitTile { X = 12, Y = 1, IsBlocked = true };
            Tiles[12, 2] = new StreetTile { X = 12, Y = 2 };
            Tiles[12, 3] = new StreetTile { X = 12, Y = 3 };
            Tiles[12, 4] = new StreetTile { X = 12, Y = 4 };
            Tiles[12, 5] = new StreetTile { X = 12, Y = 5 };
            Tiles[12, 6] = new StreetTile { X = 12, Y = 6 };
            Tiles[12, 7] = new EmptyTile { X = 12, Y = 7 };
            Tiles[12, 8] = new ExitTile { X = 12, Y = 8, IsBlocked = false };
        }

        public void AddCharacters()
        {
            Characters[0] = new SherlockHolmes { X = 6, Y = 6 };
            Characters[1] = new JohnHWatson { X = 8, Y = 8 };
            Characters[2] = new JohnSmith { X = 6, Y = 3 };
            Characters[3] = new InspecteurLestrade { X = 4, Y = 5 };
            Characters[4] = new MissStealthy { X = 0, Y = 5 };
            Characters[5] = new SergentGoodley { X = 12, Y = 4 };
            Characters[6] = new SirWilliamGull { X = 4, Y = 1 };
            Characters[7] = new JeremyBert { X = 8, Y = 4 };
        }

        public BoardDTO GetDTO()
        {
            var board = new BoardDTO();

            SetCharacterDTOs(board);
            SetTileDTOs(board);
            SetTurnSchedulerDTO(board);
            SetJackVisibilityDTO(board);
            SetJackIdentityDTO(board);

            return board;
        }

        private void SetCharacterDTOs(BoardDTO board)
        {
            board.Characters = new CharacterDTO[Characters.Length];
            for (int i = 0; i < Characters.Length; i++)
                board.Characters[i] = Characters[i].GetDTO();
        }

        private void SetTileDTOs(BoardDTO board)
        {
            var dim0 = Tiles.GetLength(0);
            var dim1 = Tiles.GetLength(1);

            board.Tiles = new TileDTO[dim0][];

            for (int i = 0; i < dim0; i++)
            {
                board.Tiles[i] = new TileDTO[dim1];
                for (int j = 0; j < dim1; j++)
                {
                    board.Tiles[i][j] = Tiles[i, j].GetDTO();
                }
            }
        }

        private void SetTurnSchedulerDTO(BoardDTO board)
        {
            board.TurnScheduler = TurnScheduler.GetDTO();
        }

        // TODO : Passer par un objet ?
        private void SetJackVisibilityDTO(BoardDTO board)
        {
            board.JackVisibility = new JackVisibilityDTO { IsVisibile = (JackVisibility == JackVisibility.Light) };
        }

        // TODO : Gérer l'identité.
        private void SetJackIdentityDTO(BoardDTO board)
        {
            board.JackIdentity = new CardDTO { CharacterId = 0, Name = "Tata" };
        }
    }
}
