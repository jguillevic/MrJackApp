using MrJackApp.DTO.Game.Board.Tile;

namespace MrJackApp.Engine.Game.Board.Tile
{
    public sealed class EmptyTile : Tile
    {
        public override bool CanGoOn => false;

        protected override TileDTO CreateDTO()
        {
            return new EmptyTileDTO();
        }
    }
}
