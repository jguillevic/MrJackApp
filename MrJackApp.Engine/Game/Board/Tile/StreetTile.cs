using MrJackApp.DTO.Game.Board.Tile;

namespace MrJackApp.Engine.Game.Board.Tile
{
    public sealed class StreetTile : Tile
    {
        public override bool CanGoOn => true;

        protected override TileDTO CreateDTO()
        {
            return new StreetTileDTO();
        }
    }
}
