using MrJackApp.DTO.Game.Board.Tile;

namespace MrJackApp.Engine.Game.Board.Tile
{
    public sealed class GasBurnerTile : Tile
    {
        public override bool CanGoOn => false;

        public bool IsOn { get; set; }

        protected override TileDTO CreateDTO()
        {
            return new GasBurnerTileDTO();
        }

        protected override void MapToDTO(TileDTO tile)
        {
            base.MapToDTO(tile);

            ((GasBurnerTileDTO)tile).IsOn = IsOn;
        }
    }
}
