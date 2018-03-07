using System;

namespace MrJackApp.ViewModel.Game.Board.Tile
{
    public sealed class TileSelectedEventArgs : EventArgs
    {
        public TileViewModel Tile { get; set; }

        public TileSelectedEventArgs() : base() { }
    }
}
