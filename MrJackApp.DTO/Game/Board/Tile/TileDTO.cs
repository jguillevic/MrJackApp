using System.Runtime.Serialization;

namespace MrJackApp.DTO.Game.Board.Tile
{
    [KnownType(typeof(EmptyTileDTO))]
    [KnownType(typeof(ExitTileDTO))]
    [KnownType(typeof(GasBurnerTileDTO))]
    [KnownType(typeof(HouseTileDTO))]
    [KnownType(typeof(ManholeTileDTO))]
    [KnownType(typeof(StreetTileDTO))]
    [DataContract]
    public abstract class TileDTO
    {
        [DataMember]
        public bool CanGoOn { get; set; }
        [DataMember]
        public int X { get; set; }
        [DataMember]
        public int Y { get; set; }
    }
}
