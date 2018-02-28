using MrJackApp.ViewModel.Common.Navigation;
using MrJackApp.WCFServiceClient.Game;
using System.Collections.Generic;

namespace MrJackApp.ViewModel.MainMenu
{
    public sealed class MainMenuViewModel : NavigationViewModel
    {
        public List<MainMenuItemViewModel> Menus { get; private set; } = new List<MainMenuItemViewModel>();

        public MainMenuViewModel(INavigationService navigationService, ServiceClientManager serviceClientManager) : base(navigationService)
        {
            Menus.Add(new QuickGameMenuItemViewModel(navigationService, serviceClientManager));
            Menus.Add(new RuleBookMenuItemViewModel(navigationService));
            Menus.Add(new AboutMenuItemViewModel(navigationService));
        }
    }
}
