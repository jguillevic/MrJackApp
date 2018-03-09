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
                var firstPlayerSessionId = OperationContext.Current.SessionId;         
                if (_lfgSessionIds.Count == 0)         
                    _lfgSessionIds.Add(firstPlayerSessionId);
                else
                {
                    var hostedGame = new HostedGame();
                    
                    string secondPlayerSessionId;
                    lock (_hostedGames)
                    {
                        secondPlayerSessionId = _lfgSessionIds[0];
                        _hostedGames.Add(secondPlayerSessionId, hostedGame);
                        _lfgSessionIds.RemoveAt(0);
                        _hostedGames.Add(firstPlayerSessionId, hostedGame);
                    }

                    hostedGame.Init(firstPlayerSessionId, secondPlayerSessionId);

                    var board = hostedGame.Game.Board.GetDTO();
                    lock (_callbacks)
                    {            
                        _callbacks[firstPlayerSessionId].BroadcastBoard(board);
                        _callbacks[secondPlayerSessionId].BroadcastBoard(board);
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

        public bool IsJack()
        {
            var playerSessionId = OperationContext.Current.SessionId;

            lock(_hostedGames)
            {
                return _hostedGames[playerSessionId].IsJack(playerSessionId);
            }
        }
    }
}
