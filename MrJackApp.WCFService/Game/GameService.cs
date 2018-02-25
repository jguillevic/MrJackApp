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
        private static Dictionary<string, Engine.Game.Game> _hostedGames = new Dictionary<string, Engine.Game.Game>();

        public void CloseSession()
        {
            var sessionId = OperationContext.Current.SessionId;
            
            lock (_lfgSessionIds)
                _lfgSessionIds.Remove(sessionId);

            lock (_callbacks)
                _callbacks.Remove(sessionId);

            lock (_hostedGames)
                _hostedGames.Remove(sessionId);
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
                    var game = new Engine.Game.Game();
                    game.Init();

                    string secondPlayerSessionId;
                    lock (_hostedGames)
                    {
                        secondPlayerSessionId = _lfgSessionIds[0];
                        _hostedGames.Add(secondPlayerSessionId, game);
                        _lfgSessionIds.RemoveAt(0);
                        _hostedGames.Add(firstPlayerSessionId, game);
                    }

                    var board = game.Board.GetDTO();
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
    }
}
