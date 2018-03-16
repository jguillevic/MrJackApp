using MrJackApp.DTO.Game.Board;
using MrJackApp.DTO.Game.Player;

namespace MrJackApp.DTO.Game
{
    public sealed class GameDTO
    {
        public BoardDTO Board { get; set; }
        public PlayerDTO Player { get; set; }
    }
}
