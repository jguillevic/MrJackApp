using MrJackApp.DTO.Game.Board.Tile;

namespace MrJackApp.Engine.Game.Board.Tile
{
    public sealed class ManholeTile : Tile
    {
        public override bool CanGoOn => true;

        public bool IsOpen { get; set; }

        protected override TileDTO CreateDTO()
        {
            return new ManholeTileDTO();
        }

        protected override void MapToDTO(TileDTO tile)
        {
            base.MapToDTO(tile);

            ((ManholeTileDTO)tile).IsOpen = IsOpen;
        }
    }
}
