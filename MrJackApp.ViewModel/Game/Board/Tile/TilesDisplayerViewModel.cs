using MrJackApp.DTO.Game.Board.Tile;
using MrJackApp.ViewModel.Common;
using System;
using System.Collections.Generic;

namespace MrJackApp.ViewModel.Game.Board.Tile
{
    public sealed class TilesDisplayerViewModel : BindableBase
    {
        public List<TileViewModel> Tiles { get; } = new List<TileViewModel>();

        public TilesDisplayerViewModel(TileDTO[][] tiles) : base()
        {
            Map(tiles);
        }

        private void Map(TileDTO[][] tiles)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                for (int j = 0; j < tiles[i].Length; j++)
                {
                    TileViewModel tileViewModel = null;
                    var tile = tiles[i][j];

                    if (tile is ExitTileDTO)
                        tileViewModel = new ExitTileViewModel((ExitTileDTO)tile);
                    else if (tile is GasBurnerTileDTO)
                        tileViewModel = new GasBurnerTileViewModel((GasBurnerTileDTO)tile);
                    else if (tile is HouseTileDTO)
                        tileViewModel = new HouseTileViewModel(tile);
                    else if (tile is ManholeTileDTO)
                        tileViewModel = new ManholeTileViewModel((ManholeTileDTO)tile);
                    else if (tile is StreetTileDTO)
                        tileViewModel = new StreetTileViewModel(tile);
                    else if (tile is EmptyTileDTO)
                        tileViewModel = new EmptyTileViewModel(tile);
                    else
                        throw new NotImplementedException();

                    tileViewModel.Selected += ManageTileViewModelSelection;

                    Tiles.Add(tileViewModel);
                }
            }
        }

        private void ManageTileViewModelSelection(object sender, EventArgs e)
        {
            RaiseTileSelected((TileViewModel)sender);
        }

        public delegate void TileSelectedEventHandler(object sender, TileSelectedEventArgs e);
        public event TileSelectedEventHandler TileSelected;

        private void RaiseTileSelected(TileViewModel tile)
        {
            TileSelected?.Invoke(this, new TileSelectedEventArgs { Tile = tile });
        }
    }
}
