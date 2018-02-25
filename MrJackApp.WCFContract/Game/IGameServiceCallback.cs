using MrJackApp.DTO.Game.Board;
using System.ServiceModel;

namespace MrJackApp.WCFContract.Game
{
    [ServiceContract]
    public interface IGameServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void BroadcastBoard(BoardDTO board);
    }
}
