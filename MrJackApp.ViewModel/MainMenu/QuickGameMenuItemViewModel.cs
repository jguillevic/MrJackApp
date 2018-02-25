using MrJackApp.ViewModel.Common.Navigation;

namespace MrJackApp.ViewModel.MainMenu
{
    public sealed class QuickGameMenuItemViewModel : MainMenuItemViewModel
    {
        public QuickGameMenuItemViewModel(INavigationService navigationService) : base(navigationService)
        {
            Label = "Partie rapide";
        }

        public override void Execute()
        {
            NavigateTo(NavigationIndex.WaitingForGame);
        }
    }
}
