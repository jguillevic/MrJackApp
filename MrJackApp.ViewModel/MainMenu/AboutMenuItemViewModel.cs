using MrJackApp.ViewModel.Common.Navigation;

namespace MrJackApp.ViewModel.MainMenu
{
    public sealed class AboutMenuItemViewModel : MainMenuItemViewModel
    {
        public AboutMenuItemViewModel(INavigationService navigationService) : base(navigationService)
        {
            Label = "A propos";
        }

        public override void Execute()
        {
            
        }
    }
}
