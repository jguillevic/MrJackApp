using MrJackApp.DTO.Game;
using MrJackApp.WCFService.Game.Player;
using System.Collections.Generic;
using System;
using MrJackApp.WCFService.Game.Session;

namespace MrJackApp.WCFService.Game
{
    public sealed class HostedGame
    {
        private Player.Player _player;
        private Engine.Game.Game _game;

        public HostedGame(PlayerKind kind, string login, Engine.Game.Game game)
        {
            _player = new Player.Player(kind, login);
            _game = game;
        }

        public GameDTO GetDTO()
        {
            var game = new GameDTO();

            game.Player = _player.GetDTO();
            game.Board = _game.Board.GetDTO();

            return game;
        }

        public static Dictionary<string, HostedGame> Create(LfgSession session1, LfgSession session2)
        {
            var result = new Dictionary<string, HostedGame>();

            var game = new Engine.Game.Game();
            game.Init();

            var isFirstPlayerJack = GetRandomBool();

            if (isFirstPlayerJack)
            {
                result.Add(session1.SessionId, new HostedGame(PlayerKind.Jack, session1.Login, game));
                result.Add(session2.SessionId, new HostedGame(PlayerKind.Inspector, session2.Login, game));
            }
            else
            {
                result.Add(session2.SessionId, new HostedGame(PlayerKind.Jack, session2.Login, game));
                result.Add(session1.SessionId, new HostedGame(PlayerKind.Inspector, session1.Login, game));
            }

            return result;
        }

        private static bool GetRandomBool()
        {
            return new Random().Next(100) % 2 == 0;
        }
    }
}
