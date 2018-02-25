using MrJackApp.DTO.Game.Board.Turn;

namespace MrJackApp.Engine.Game.Board.Turn
{
    public sealed class Turn
    {
        public int Value { get; set; }
        public bool IsCurrent { get; set; }

        public TurnDTO GetDTO()
        {
            var turn = new TurnDTO();

            turn.Value = Value;
            turn.IsCurrent = IsCurrent;

            return turn;
        }
    }
}
