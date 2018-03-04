using MrJackApp.Service.Navigation;
using MrJackApp.Service.Sound.Effect;

namespace MrJackApp.ViewModel.MainMenu
{
    public sealed class RuleBookMenuItemViewModel : MainMenuItemViewModel
    {
        public RuleBookMenuItemViewModel(INavigationService navigationService, IEffectController effectController) : base(navigationService, effectController)
        {
            Label = "Règles";
        }

        public override void Execute()
        {
            NavigateTo(NavigationIndex.RuleBook);
        }
    }
}
