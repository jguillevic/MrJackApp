using MrJackApp.Service.Navigation;
using MrJackApp.Service.Sound.Effect;

namespace MrJackApp.ViewModel.MainMenu
{
    public sealed class AboutMenuItemViewModel : MainMenuItemViewModel
    {
        public AboutMenuItemViewModel(INavigationService navigationService, IEffectController effectController) : base(navigationService, effectController)
        {
            Label = "A propos";
        }

        public override void Execute()
        {
            
        }
    }
}
