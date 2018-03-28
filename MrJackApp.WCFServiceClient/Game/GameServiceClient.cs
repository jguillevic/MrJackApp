using MrJackApp.WCFContract.Game;
using MrJackApp.WCFServiceCallback.Game;
using System.ServiceModel;

namespace MrJackApp.WCFServiceClient.Game
{
    public sealed class GameServiceClient : IGameService
    {
        private IGameService _service;
        private string _configName;

        public GameServiceCallback Callback { get; } = new GameServiceCallback();

        public GameServiceClient(string configName)
        {
            _configName = configName;

            var channelFactory = new DuplexChannelFactory<IGameService>(Callback, _configName);
            _service = channelFactory.CreateChannel();
        }

        public void CloseSession()
        {
            _service.CloseSession();
        }

        public void LookingForQuickGame(string login)
        {
            _service.LookingForQuickGame(login);
        }

        public void OpenSession()
        {
            _service.OpenSession();
        }

        public void StopLookingForQuickGame()
        {
            _service.StopLookingForQuickGame();
        }
    }
}
