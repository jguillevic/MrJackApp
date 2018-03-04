using MrJackApp.Service.Navigation;
using MrJackApp.Service.Sound.Effect;
using MrJackApp.WCFServiceClient.Game;

namespace MrJackApp.ViewModel.MainMenu
{
    public sealed class QuickGameMenuItemViewModel : MainMenuItemViewModel
    {
        private ServiceClientManager _serviceClientManager;

        public QuickGameMenuItemViewModel(INavigationService navigationService, IEffectController effectController, ServiceClientManager serviceClientManager) : base(navigationService, effectController)
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
