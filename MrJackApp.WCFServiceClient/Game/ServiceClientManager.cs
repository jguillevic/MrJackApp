namespace MrJackApp.WCFServiceClient.Game
{
    public class ServiceClientManager
    {
        private string _configName;

        public GameServiceClient GameServiceClient { get; private set; }

        public ServiceClientManager()
        {
            _configName = "ConfigClient";

            GameServiceClient = new GameServiceClient(_configName);
        }

        public void OpenSession()
        {
            GameServiceClient.OpenSession();
        }

        public void CloseSession()
        {
            GameServiceClient.CloseSession();
        }
    }
}
