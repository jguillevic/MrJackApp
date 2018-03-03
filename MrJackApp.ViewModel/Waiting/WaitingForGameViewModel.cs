using MrJackApp.Service.Navigation;
using MrJackApp.ViewModel.Common.Command;
using MrJackApp.ViewModel.Common.Navigation;
using MrJackApp.WCFServiceCallback.Game;
using MrJackApp.WCFServiceClient.Game;
using System.Windows.Input;

namespace MrJackApp.ViewModel.Waiting
{
    public sealed class WaitingForGameViewModel : NavigationViewModel
    {
        private ServiceClientManager _serviceClientManager;

        public ICommand CancelCommand { get; private set; }

        public WaitingForGameViewModel(INavigationService navigationService, ServiceClientManager serviceClientManager) : base(navigationService)
        {
            CancelCommand = new DelegateCommand(CancelCommandExecute);

            _serviceClientManager = serviceClientManager;
            _serviceClientManager.GameServiceClient.Callback.BoardReceived += CallbackBoardReceived;
        }

        private void CallbackBoardReceived(object sender, BoardReceivedEventArgs e)
        {
            _serviceClientManager.GameServiceClient.Callback.BoardReceived -= CallbackBoardReceived;
            NavigateTo(NavigationIndex.Game, e.Board);
        }

        private void CancelCommandExecute()
        {
            _serviceClientManager.GameServiceClient.StopLookingForQuickGame();

            GoBack();
        }
    }
}
