using MrJackApp.ViewModel.Common.Command;
using MrJackApp.ViewModel.Common.Navigation;
using MrJackApp.WCFServiceCallback.Game;
using MrJackApp.WCFServiceClient.Game;
using System.Windows.Input;

namespace MrJackApp.ViewModel.Waiting
{
    public sealed class WaitingForGameViewModel : NavigationViewModel
    {
        private GameServiceClient _gameServiceClient;

        public ICommand CancelCommand { get; private set; }

        public WaitingForGameViewModel(INavigationService navigationService, GameServiceClient gameServiceClient) : base(navigationService)
        {      
            CancelCommand = new DelegateCommand(CancelCommandExecute);

            _gameServiceClient = gameServiceClient;
            _gameServiceClient.Callback.BoardReceived += CallbackBoardReceived;

            _gameServiceClient.OpenSession();
            _gameServiceClient.LookingForQuickGame();
        }

        private void CallbackBoardReceived(object sender, BoardReceivedEventArgs e)
        {
            _gameServiceClient.Callback.BoardReceived -= CallbackBoardReceived;
            NavigateTo(NavigationIndex.Game, e.Board);
        }

        private void CancelCommandExecute()
        {
            GoBack();
        }
    }
}
