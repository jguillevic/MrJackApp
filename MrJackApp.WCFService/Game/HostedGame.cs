using System;

namespace MrJackApp.WCFService.Game
{
    public sealed class HostedGame
    {
        private string _inspectorId;
        private string _jackId;
        public Engine.Game.Game Game { get; private set; } = new Engine.Game.Game();

        public void Init(string player1Id, string player2Id)
        {
            SetPlayerIds(player1Id, player2Id);

            Game.Init();
        }

        private void SetPlayerIds(string player1Id, string player2Id)
        {
            var rand = new Random();
            var result = rand.Next(0, 1);
            if (result == 0)
            {
                _inspectorId = player1Id;
                _jackId = player2Id;
            }
            else
            {
                _inspectorId = player2Id;
                _jackId = player1Id;
            }
        }

        public bool IsJack(string playerId)
        {
            return _jackId == playerId;
        }

        public bool IsInspector(string playerId)
        {
            return _inspectorId == playerId;
        }
    }
}
