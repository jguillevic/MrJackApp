using System.Runtime.Serialization;

namespace MrJackApp.DTO.Game.Board.Tile
{
    [DataContract]
    public sealed class ManholeTileDTO : TileDTO
    {
        [DataMember]
        public bool IsOpen { get; set; }
    }
}
