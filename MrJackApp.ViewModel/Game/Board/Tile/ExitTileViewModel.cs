using MrJackApp.DTO.Game.Board.Tile;

namespace MrJackApp.ViewModel.Game.Board.Tile
{
    public sealed class ExitTileViewModel : TileViewModel
    {
        public bool IsBlocked { get; set; }

        public ExitTileViewModel(TileDTO tile) : base(tile) { }

        protected override void Map(TileDTO tile)
        {
            base.Map(tile);

            IsBlocked = ((ExitTileDTO)tile).IsBlocked;
        }
    }
}
