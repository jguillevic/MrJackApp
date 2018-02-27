using MrJackApp.ViewModel.Common.Navigation;
using MrJackApp.WCFServiceClient.Game;

namespace MrJackApp.ViewModel.MainMenu
{
    public sealed class QuickGameMenuItemViewModel : MainMenuItemViewModel
    {
        private ServiceClientManager _serviceClientManager;

        public QuickGameMenuItemViewModel(INavigationService navigationService, ServiceClientManager serviceClientManager) : base(navigationService)
        {
            Label = "Partie rapide";

            _serviceClientManager = serviceClientManager;
        }

        public override void Execute()
        {
            _serviceClientManager.GameServiceClient.LookingForQuickGame();

            NavigateTo(NavigationIndex.WaitingForGame);
        }
    }
}
