using MrJackApp.Service.Navigation;

namespace MrJackApp.ViewModel.MainMenu
{
    public sealed class RuleBookMenuItemViewModel : MainMenuItemViewModel
    {
        public RuleBookMenuItemViewModel(INavigationService navigationService) : base(navigationService)
        {
            Label = "Règles";
        }

        public override void Execute()
        {
            NavigateTo(NavigationIndex.RuleBook);
        }
    }
}
