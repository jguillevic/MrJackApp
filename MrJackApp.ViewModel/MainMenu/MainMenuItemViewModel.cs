using MrJackApp.Service.Navigation;
using MrJackApp.Service.Sound.Effect;
using MrJackApp.ViewModel.Common.Command;
using MrJackApp.ViewModel.Common.Navigation;
using System.Windows.Input;

namespace MrJackApp.ViewModel.MainMenu
{
    public abstract class MainMenuItemViewModel : NavigationViewModel
    {
        private string _label;
        public string Label
        {
            get { return _label; }
            set { SetProperty(ref _label, value); }
        }

        public ICommand ActionCommand { get; private set; }
        public IEffectController EffectController { get; private set; }

        public MainMenuItemViewModel(INavigationService navigationService, IEffectController effectController) : base(navigationService)
        {
            ActionCommand = new DelegateCommand(Execute);
            EffectController = effectController;
        }

        public abstract void Execute();
    }
}
