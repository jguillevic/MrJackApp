using MrJackApp.DTO.Game;
using MrJackApp.WCFContract.Game;
using System.ServiceModel;

namespace MrJackApp.WCFServiceCallback.Game
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Single, UseSynchronizationContext = false)]
    public class GameServiceCallback : IGameServiceCallback
    {
        public void BroadcastGame(GameDTO game)
        {
            RaiseGameReceived(game);
        }

        public delegate void GameReceivedEventHandler(object sender, GameReceivedEventArgs e);
        public event GameReceivedEventHandler GameReceived;

        private void RaiseGameReceived(GameDTO game)
        {
            GameReceived?.Invoke(this, new GameReceivedEventArgs { Game = game });
        }
    }
}
