namespace MrJackApp.WCFService.Game
{
    public sealed class HostedGame
    {
        public string InspectorId { get; private set; }
        public string JackId { get; private set; }
        public Engine.Game.Game Game { get; private set; }

        public HostedGame(string inspectorId, string jackId)
        {
            InspectorId = inspectorId;
            JackId = jackId;
            Game = new Engine.Game.Game();
        }

        public void Init()
        {
            Game.Init();
        }
    }
}
