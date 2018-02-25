using MrJackApp.DTO.Game.Board;
using System;

namespace MrJackApp.WCFServiceCallback.Game
{
    public sealed class BoardReceivedEventArgs : EventArgs
    {
        public BoardDTO Board { get; set; }

        public BoardReceivedEventArgs() : base() { }
    }
}
