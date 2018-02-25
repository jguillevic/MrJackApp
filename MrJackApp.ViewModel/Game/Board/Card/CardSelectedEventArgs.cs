using System;

namespace MrJackApp.ViewModel.Game.Board.Card
{
    public sealed class CardSelectedEventArgs : EventArgs
    {
        public CardViewModel Card { get; set; }

        public CardSelectedEventArgs() : base() { }
    }
}
