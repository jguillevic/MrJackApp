using MrJackApp.WCFContract.Game;
using MrJackApp.WCFServiceCallback.Game;
using System.ServiceModel;

namespace MrJackApp.WCFServiceClient.Game
{
    public sealed class GameServiceClient : IGameService
    {
        private IGameService _service;
        private string _configName;
        private bool _isClose = true;

        public GameServiceCallback Callback { get; } = new GameServiceCallback();

        public GameServiceClient(string configName)
        {
            _configName = configName;     
        }

        public void CloseSession()
        {
            _service.CloseSession();

            _isClose = true;
            _service = null;
        }

        public void LookingForQuickGame()
        {
            _service.LookingForQuickGame();
        }

        public void OpenSession()
        {
            if (_isClose)
            {
                var channelFactory = new DuplexChannelFactory<IGameService>(Callback, _configName);
                _service = channelFactory.CreateChannel();
            }

            _service.OpenSession();

            _isClose = false;
        }
    }
}
