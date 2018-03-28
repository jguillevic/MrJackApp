using MrJackApp.Service.Navigation;
using MrJackApp.Service.Sound.Effect;

namespace MrJackApp.ViewModel.MainMenu
{
    public sealed class QuickGameMenuItemViewModel : MainMenuItemViewModel
    {
        public QuickGameMenuItemViewModel(INavigationService navigationService, IEffectController effectController) : base(navigationService, effectController)
        {
            Label = "Partie rapide";
        }

        public override void Execute()
        {
            NavigateTo(NavigationIndex.InputLogin);
        }
    }
}
