using MrJackApp.DTO.Game;
using MrJackApp.WCFService.Game.Player;
using System.Collections.Generic;
using System;

namespace MrJackApp.WCFService.Game
{
    public sealed class HostedGame
    {
        private Player.Player _player;
        private Engine.Game.Game _game;

        public HostedGame(PlayerKind kind, Engine.Game.Game game)
        {
            _player = new Player.Player(kind);
            _game = game;
        }

        public GameDTO GetDTO()
        {
            var game = new GameDTO();

            game.Player = _player.GetDTO();
            game.Board = _game.Board.GetDTO();

            return game;
        }

        public static Dictionary<string, HostedGame> CreateFromPlayerIds(string player1Id, string player2Id)
        {
            var result = new Dictionary<string, HostedGame>();

            var game = new Engine.Game.Game();
            game.Init();

            var isFirstPlayerJack = GetRandomBool();

            if (isFirstPlayerJack)
            {
                result.Add(player1Id, new HostedGame(PlayerKind.Jack, game));
                result.Add(player2Id, new HostedGame(PlayerKind.Inspector, game));
            }
            else
            {
                result.Add(player2Id, new HostedGame(PlayerKind.Jack, game));
                result.Add(player1Id, new HostedGame(PlayerKind.Inspector, game));
            }

            return result;
        }

        private static bool GetRandomBool()
        {
            return new Random().Next(100) % 2 == 0;
        }
    }
}
