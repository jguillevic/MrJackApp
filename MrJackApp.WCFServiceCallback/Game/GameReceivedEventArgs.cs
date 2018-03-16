using MrJackApp.DTO.Game;
using System;

namespace MrJackApp.WCFServiceCallback.Game
{
    public sealed class GameReceivedEventArgs : EventArgs
    {
        public GameDTO Game { get; set; }

        public GameReceivedEventArgs() : base() { }
    }
}
