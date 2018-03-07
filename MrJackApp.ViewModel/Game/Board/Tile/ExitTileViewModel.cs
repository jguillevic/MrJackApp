using MrJackApp.DTO.Game.Board.Tile;

namespace MrJackApp.ViewModel.Game.Board.Tile
{
    public sealed class ExitTileViewModel : TileViewModel
    {
        public bool IsBlocked { get; set; }

        public ExitTileViewModel(ExitTileDTO tile) : base(tile)
        {
            Map(tile);
        }

        private void Map(ExitTileDTO tile)
        {
            IsBlocked = tile.IsBlocked;
        }
    }
}
