using System.Runtime.Serialization;

namespace MrJackApp.DTO.Game.Board.Tile
{
    [DataContract]
    public sealed class GasBurnerTileDTO : TileDTO
    {
        [DataMember]
        public bool IsOn { get; set; }
    }
}
