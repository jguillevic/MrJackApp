using MrJackApp.DTO.Game.Board.Tile;

namespace MrJackApp.ViewModel.Game.Board.Tile
{
    public sealed class ManholeTileViewModel : TileViewModel
    {
        public bool IsOpen { get; set; }

        public ManholeTileViewModel(ManholeTileDTO tile) : base(tile)
        {
            Map(tile);
        }

        private void Map(ManholeTileDTO tile)
        {
            IsOpen = tile.IsOpen;
        }
    }
}
