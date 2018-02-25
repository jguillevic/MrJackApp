using MrJackApp.DTO.Game.Board.Tile;

namespace MrJackApp.Engine.Game.Board.Tile
{
    public sealed class ExitTile : Tile
    {
        public override bool CanGoOn => true;

        public bool IsBlocked { get; set; }

        protected override TileDTO CreateDTO()
        {
            return new ExitTileDTO();
        }

        protected override void MapToDTO(TileDTO tile)
        {
            base.MapToDTO(tile);

            ((ExitTileDTO)tile).IsBlocked = IsBlocked;
        }
    }
}
