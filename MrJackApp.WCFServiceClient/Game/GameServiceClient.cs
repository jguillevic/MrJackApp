using MrJackApp.WCFContract.Game;
using MrJackApp.WCFServiceCallback.Game;
using System.ServiceModel;

namespace MrJackApp.WCFServiceClient.Game
{
    public sealed class GameServiceClient : IGameService
    {
        private IGameService _service;
        public GameServiceCallback Callback { get; private set; }

        public GameServiceClient(string configName)
        {
            Callback = new GameServiceCallback();
            var channelFactory = new DuplexChannelFactory<IGameService>(Callback, configName);
            _service = channelFactory.CreateChannel();
        }

        public void CloseSession()
        {
            _service.CloseSession();
        }

        public void LookingForQuickGame()
        {
            _service.LookingForQuickGame();
        }

        public void OpenSession()
        {
            _service.OpenSession();
        }
    }
}
