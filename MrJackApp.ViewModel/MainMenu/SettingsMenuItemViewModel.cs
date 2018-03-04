using MrJackApp.Service.Navigation;
using MrJackApp.Service.Sound.Effect;

namespace MrJackApp.ViewModel.MainMenu
{
    public sealed class SettingsMenuItemViewModel : MainMenuItemViewModel
    {
        public SettingsMenuItemViewModel(INavigationService navigationService, IEffectController effectController) : base(navigationService, effectController)
        {
            Label = "Paramètres";
        }

        public override void Execute()
        {
            NavigateTo(NavigationIndex.Settings);
        }
    }
}
