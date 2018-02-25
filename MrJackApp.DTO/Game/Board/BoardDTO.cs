using MrJackApp.DTO.Game.Board.Card;
using MrJackApp.DTO.Game.Board.Character;
using MrJackApp.DTO.Game.Board.Tile;
using MrJackApp.DTO.Game.Board.Turn;
using System.Runtime.Serialization;

namespace MrJackApp.DTO.Game.Board
{
    [DataContract]
    public sealed class BoardDTO
    {
        [DataMember]
        public TileDTO[][] Tiles { get; set; }
        [DataMember]
        public CharacterDTO[] Characters { get; set; }
        [DataMember]
        public JackVisibilityDTO JackVisibility { get; set; }
        [DataMember]
        public CardDTO JackIdentity { get; set; }
        [DataMember]
        public TurnSchedulerDTO TurnScheduler { get; set; }
    }
}
