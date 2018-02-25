using MrJackApp.ViewModel.Common.Navigation;
using System.Collections.Generic;

namespace MrJackApp.ViewModel.MainMenu
{
    public sealed class MainMenuViewModel : NavigationViewModel
    {
        public List<MainMenuItemViewModel> Menus { get; private set; } = new List<MainMenuItemViewModel>();

        public MainMenuViewModel(INavigationService navigationService) : base(navigationService)
        {
            Menus.Add(new QuickGameMenuItemViewModel(navigationService));
            Menus.Add(new AboutMenuItemViewModel(navigationService));
        }
    }
}
