using MrJackApp.Service.Navigation;
using MrJackApp.Service.Sound.Effect;

namespace MrJackApp.ViewModel.MainMenu
{
    public sealed class QuitMenuItemViewModel : MainMenuItemViewModel
    {
        public QuitMenuItemViewModel(INavigationService navigationService, IEffectController effectController) : base(navigationService, effectController)
        {
            Label = "Quitter";
        }

        public override void Execute()
        {
            
        }
    }
}
