using MrJackApp.DTO.Game.Board.Tile;

namespace MrJackApp.ViewModel.Game.Board.Tile
{
    public sealed class GasBurnerTileViewModel : TileViewModel
    {
        public bool IsOn { get; set; }

        public GasBurnerTileViewModel(TileDTO tile) : base(tile) { }

        protected override void Map(TileDTO tile)
        {
            base.Map(tile);

            IsOn = ((GasBurnerTileDTO)tile).IsOn;
        }
    }
}
