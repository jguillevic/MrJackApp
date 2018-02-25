using MrJackApp.DTO.Game.Board.Tile;

namespace MrJackApp.ViewModel.Game.Board.Tile
{
    public sealed class ManholeTileViewModel : TileViewModel
    {
        public bool IsOpen { get; set; }

        public ManholeTileViewModel(TileDTO tile) : base(tile) { }

        protected override void Map(TileDTO tile)
        {
            base.Map(tile);

            IsOpen = ((ManholeTileDTO)tile).IsOpen;
        }
    }
}
