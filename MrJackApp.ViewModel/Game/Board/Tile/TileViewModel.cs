using MrJackApp.DTO.Game.Board.Tile;
using MrJackApp.ViewModel.Common;
using MrJackApp.ViewModel.Common.Command;
using System;
using System.Windows.Input;

namespace MrJackApp.ViewModel.Game.Board.Tile
{
    public abstract class TileViewModel : BindableBase
    {
        public ICommand SelectionCommand { get; private set; }

        public bool ShowCoordinate
        {
            get
            {
                //#if DEBUG
                //                return true;
                //#else
                //                return false;
                //#endif

                return false;

            }
        }

        public bool CanGoOn { get; private set; }
        public Coordinate Coordinate { get; private set; }

        public TileViewModel(TileDTO tile) : base()
        {
            Map(tile);
            SetCommands();
        }

        private void SetCommands()
        {
            SelectionCommand = new DelegateCommand(() => RaiseSelected());
        }

        private void Map(TileDTO tile)
        {
            CanGoOn = tile.CanGoOn;
            Coordinate = new Coordinate(tile.X, tile.Y);
        }

        public delegate void SelectedEventHandler(object sender, EventArgs e);
        public event SelectedEventHandler Selected;

        private void RaiseSelected()
        {
            Selected?.Invoke(this, EventArgs.Empty);
        }
    }
}
