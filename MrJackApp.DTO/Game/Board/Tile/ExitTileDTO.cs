using System.Runtime.Serialization;

namespace MrJackApp.DTO.Game.Board.Tile
{
    [DataContract]
    public sealed class ExitTileDTO : TileDTO
    {
        [DataMember]
        public bool IsBlocked { get; set; }
    }
}
