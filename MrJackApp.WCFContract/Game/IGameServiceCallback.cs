using MrJackApp.DTO.Game;
using System.ServiceModel;

namespace MrJackApp.WCFContract.Game
{
    [ServiceContract]
    public interface IGameServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void BroadcastGame(GameDTO game);
    }
}
