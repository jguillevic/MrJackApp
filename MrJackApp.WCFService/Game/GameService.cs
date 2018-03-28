using MrJackApp.WCFContract.Game;
using MrJackApp.WCFService.Game.Session;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;

namespace MrJackApp.WCFService.Game
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Single)]
    public class GameService : IGameService
    {
        private static List<LfgSession> _lfgSessions = new List<LfgSession>();
        private static Dictionary<string, IGameServiceCallback> _callbacks = new Dictionary<string, IGameServiceCallback>();
        private static Dictionary<string, HostedGame> _hostedGames = new Dictionary<string, HostedGame>();

        public void CloseSession()
        {
            var sessionId = OperationContext.Current.SessionId;

            lock (_callbacks)
                _callbacks.Remove(sessionId);
        }

        public void LookingForQuickGame(string login)
        {
            lock (_lfgSessions)
            {
                var player1Session = new LfgSession { SessionId = OperationContext.Current.SessionId, Login = login };
                if (_lfgSessions.Count == 0)
                    _lfgSessions.Add(player1Session);
                else
                {
                    LfgSession player2Session;
                    lock (_hostedGames)
                    {
                        player2Session = _lfgSessions[0];
                        var result = HostedGame.Create(player1Session, player2Session);
                        _lfgSessions.RemoveAt(0);

                        foreach (var value in result)
                            _hostedGames.Add(value.Key, value.Value);
                    }

                    lock (_callbacks)
                    {
                        _callbacks[player1Session.SessionId].BroadcastGame(_hostedGames[player1Session.SessionId].GetDTO());
                        _callbacks[player2Session.SessionId].BroadcastGame(_hostedGames[player2Session.SessionId].GetDTO());
                    }
                }
            }
        }

        public void OpenSession()
        {
            var sessionId = OperationContext.Current.SessionId;
            var callback = OperationContext.Current.GetCallbackChannel<IGameServiceCallback>();

            lock (_callbacks)
                _callbacks.Add(sessionId, callback);
        }

        public void StopLookingForQuickGame()
        {
            var sessionId = OperationContext.Current.SessionId;

            lock (_lfgSessions)
                _lfgSessions.Remove(_lfgSessions.First(item => item.SessionId == sessionId));

            lock (_hostedGames)
                _hostedGames.Remove(sessionId);
        }
    }
}
