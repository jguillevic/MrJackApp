using System.ServiceModel;

namespace MrJackApp.WCFContract.Game
{
    [ServiceContract(CallbackContract = typeof(IGameServiceCallback), SessionMode = SessionMode.Required)]
    public interface IGameService
    {
        [OperationContract(IsInitiating = true, IsTerminating = false, IsOneWay = true)]
        void OpenSession();

        [OperationContract(IsInitiating = false, IsTerminating = true, IsOneWay = true)]
        void CloseSession();

        [OperationContract(IsInitiating = false, IsTerminating = false, IsOneWay = true)]
        void LookingForQuickGame(string login);

        [OperationContract(IsInitiating = false, IsTerminating = false, IsOneWay = true)]
        void StopLookingForQuickGame();
    }
}
