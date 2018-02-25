using MrJackApp.DTO.Game.Board.Tile;

namespace MrJackApp.Engine.Game.Board.Tile
{
    public abstract class Tile
    {
        public abstract bool CanGoOn { get; }
        public int X { get; set; }
        public int Y { get; set; }

        protected abstract TileDTO CreateDTO();

        protected virtual void MapToDTO(TileDTO tile)
        {
            tile.CanGoOn = CanGoOn;
            tile.X = X;
            tile.Y = Y;
        }

        public TileDTO GetDTO()
        {
            var tile = CreateDTO();

            MapToDTO(tile);

            return tile;
        }
    }
}
