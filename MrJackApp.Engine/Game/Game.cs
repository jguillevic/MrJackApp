using MrJackApp.Engine.Game.Board.Card;
using MrJackApp.Engine.Game.Player;

namespace MrJackApp.Engine.Game
{
    public sealed class Game
    {
        private CharacterDeck _characterDeck;
        private AlibiDeck _alibiDeck;

        private InspectorPlayer _inspector;
        private JackPlayer _jack;

        public Board.Board Board { get; private set; }

        private GameResultState _result;

        public Game()
        {
            _characterDeck = new CharacterDeck();
            _alibiDeck = new AlibiDeck();

            _inspector = new InspectorPlayer();
            _jack = new JackPlayer();

            Board = new Board.Board();
        }

        public void Init()
        {
            _result = GameResultState.None;

            // TODO : Mettre ce code dans Board.
            _characterDeck.Init();
            _characterDeck.Shuffle();

            _alibiDeck.Init();
            _alibiDeck.Shuffle();

            Board.Init();
        }

        public bool ProceedTurn()
        {
            #region 1. Choix et activation des personnages.

            var drawedChar = _characterDeck.Draw(4);

            // S'il s'agit d'un tour impair.
            if (Board.TurnScheduler.CurrentTurnValue % 2 != 0)
            {
                _inspector.PlayCharacter(_inspector.ChooseCharacter(drawedChar));

                _jack.PlayCharacter(_jack.ChooseCharacter(drawedChar));
                _jack.PlayCharacter(_jack.ChooseCharacter(drawedChar));

                _inspector.PlayCharacter(_inspector.ChooseCharacter(drawedChar));
            }
            // S'il s'agit d'un tour pair.
            else
            {
                _jack.PlayCharacter(_inspector.ChooseCharacter(drawedChar));

                _inspector.PlayCharacter(_jack.ChooseCharacter(drawedChar));
                _inspector.PlayCharacter(_jack.ChooseCharacter(drawedChar));

                _jack.PlayCharacter(_inspector.ChooseCharacter(drawedChar));
            }

            #endregion 1. Choix et activation des personnages.

            #region 2. Appel à témoin : Déterminer la visibilité de Jack.

            Board.JackVisibility = _jack.SetVisibility();

            #endregion 2. Appel à témoin : Déterminer la visibilité de Jack.

            #region 3. Extinction d'un bec à gaz : Pour les tours 1 à 4, retirer le bec correspondant.

            #endregion 3. Extinction d'un bec à gaz : Pour les tours 1 à 4, retirer le bec correspondant.

            #region 4. Fin de tour.

            // S'il s'agit d'un tour pair.
            if (Board.TurnScheduler.CurrentTurnValue % 2 == 0)
            {
                _characterDeck.Init();
                _characterDeck.Shuffle();
            }

            // Déterminer si Jack a gagné.
            if (Board.TurnScheduler.IsLastTurn)
                _result = GameResultState.JackWin;
            else
                Board.TurnScheduler.NextTurn();

            #endregion 4. Fin de tour.

            return _result == GameResultState.None;
        }
    }
}
