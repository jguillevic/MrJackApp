using MrJackApp.WCFContract.Game;
using MrJackApp.WCFServiceCallback.Game;
using System.ServiceModel;
using System;

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

        public void LookingForQuickGame()
        {
            _service.LookingForQuickGame();
        }

        public void OpenSession()
        {
            _service.OpenSession();
        }

        public void StopLookingForQuickGame()
        {
            _service.StopLookingForQuickGame();
        }

        public bool IsJack()
        {
            return _service.IsJack();
        }
    }
}
