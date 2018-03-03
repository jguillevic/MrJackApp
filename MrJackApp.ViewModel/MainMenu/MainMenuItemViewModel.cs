using MrJackApp.Service.Navigation;
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

        public ICommand ActionCommand { get; set; }

        public MainMenuItemViewModel(INavigationService navigationService) : base(navigationService)
        {
            ActionCommand = new DelegateCommand(Execute);
        }

        public abstract void Execute();
    }
}
