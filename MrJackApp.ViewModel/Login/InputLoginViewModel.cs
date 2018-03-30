using MrJackApp.Service.Navigation;
using MrJackApp.Service.Sound.Effect;
using MrJackApp.ViewModel.Common.Command;
using MrJackApp.ViewModel.Common.Navigation;
using MrJackApp.WCFServiceClient.Game;
using System.Windows.Input;

namespace MrJackApp.ViewModel.Login
{
    public class InputLoginViewModel : NavigationViewModel
    {
        private ServiceClientManager _serviceClientManager;

        private string _login;
        public string Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }

        public IEffectController EffectController { get; private set; }

        public ICommand ValidateLoginCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public InputLoginViewModel(INavigationService navigationService, IEffectController effectController, ServiceClientManager serviceClientManager) : base(navigationService)
        {
            _serviceClientManager = serviceClientManager;

            EffectController = effectController;

            ValidateLoginCommand = new DelegateCommand(ValidateLoginCommandExecute);
            CancelCommand = new DelegateCommand(CancelCommandExecute);
        }

        private void ValidateLoginCommandExecute()
        {
            if (ValidateLogin())
            {
                _serviceClientManager.GameServiceClient.LookingForQuickGame(Login);

                NavigateTo(NavigationIndex.WaitingForGame);
            }
        }

        private bool ValidateLogin()
        {
            return !string.IsNullOrWhiteSpace(Login);
        }

        private void CancelCommandExecute()
        {
            GoBack();
        }
    }
}
