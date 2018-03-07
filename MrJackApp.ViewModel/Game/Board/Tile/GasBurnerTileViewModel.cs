using MrJackApp.DTO.Game.Board.Tile;

namespace MrJackApp.ViewModel.Game.Board.Tile
{
    public sealed class GasBurnerTileViewModel : TileViewModel
    {
        public bool IsOn { get; set; }

        public GasBurnerTileViewModel(GasBurnerTileDTO tile) : base(tile)
        {
            Map(tile);
        }

        private void Map(GasBurnerTileDTO tile)
        {
            IsOn = tile.IsOn;
        }
    }
}
