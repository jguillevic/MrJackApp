using MrJackApp.WCFContract.Game;
using System.Collections.Generic;
using System.ServiceModel;

namespace MrJackApp.WCFService.Game
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Single)]
    public class GameService : IGameService
    {
        private static List<string> _lfgSessionIds = new List<string>();
        private static Dictionary<string, IGameServiceCallback> _callbacks = new Dictionary<string, IGameServiceCallback>();
        private static Dictionary<string, HostedGame> _hostedGames = new Dictionary<string, HostedGame>();

        public void CloseSession()
        {
            var sessionId = OperationContext.Current.SessionId;

            lock (_callbacks)
                _callbacks.Remove(sessionId);
        }

        public void LookingForQuickGame()
        {
            lock (_lfgSessionIds)
            {
                var player1SessionId = OperationContext.Current.SessionId;
                if (_lfgSessionIds.Count == 0)
                    _lfgSessionIds.Add(player1SessionId);
                else
                {
                    string player2SessionId;
                    lock (_hostedGames)
                    {
                        player2SessionId = _lfgSessionIds[0];
                        var result = HostedGame.CreateFromPlayerIds(player1SessionId, player2SessionId);
                        _lfgSessionIds.RemoveAt(0);

                        foreach (var value in result)
                            _hostedGames.Add(value.Key, value.Value);
                    }

                    lock (_callbacks)
                    {
                        _callbacks[player1SessionId].BroadcastGame(_hostedGames[player1SessionId].GetDTO());
                        _callbacks[player2SessionId].BroadcastGame(_hostedGames[player2SessionId].GetDTO());
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

            lock (_lfgSessionIds)
                _lfgSessionIds.Remove(sessionId);

            lock (_hostedGames)
                _hostedGames.Remove(sessionId);
        }
    }
}
