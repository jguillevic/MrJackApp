using MrJackApp.DTO.Game.Board;
using MrJackApp.WCFContract.Game;
using System.ServiceModel;

namespace MrJackApp.WCFServiceCallback.Game
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Single, UseSynchronizationContext = false)]
    public class GameServiceCallback : IGameServiceCallback
    {
        public void BroadcastBoard(BoardDTO board)
        {
            RaiseBoardReceived(board);
        }

        public delegate void BoardReceivedEventHandler(object sender, BoardReceivedEventArgs e);
        public event BoardReceivedEventHandler BoardReceived;

        private void RaiseBoardReceived(BoardDTO board)
        {
            BoardReceived?.Invoke(this, new BoardReceivedEventArgs { Board = board });
        }
    }
}
