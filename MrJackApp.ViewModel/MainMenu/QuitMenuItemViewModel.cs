using MrJackApp.Service.App;
using MrJackApp.Service.Navigation;
using MrJackApp.Service.Sound.Effect;

namespace MrJackApp.ViewModel.MainMenu
{
    public sealed class QuitMenuItemViewModel : MainMenuItemViewModel
    {
        private IAppService _appService;

        public QuitMenuItemViewModel(INavigationService navigationService, IEffectController effectController, IAppService appService) : base(navigationService, effectController)
        {
            Label = "Quitter";

            _appService = appService;
        }

        public override void Execute()
        {
            _appService.Close();
        }
    }
}
