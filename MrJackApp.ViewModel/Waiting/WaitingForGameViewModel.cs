﻿using MrJackApp.Service.Navigation;
using MrJackApp.Service.Sound.Effect;
using MrJackApp.ViewModel.Common.Command;
using MrJackApp.ViewModel.Common.Navigation;
using MrJackApp.WCFServiceCallback.Game;
using MrJackApp.WCFServiceClient.Game;
using System.Windows.Input;

namespace MrJackApp.ViewModel.Waiting
{
    public sealed class WaitingForGameViewModel : NavigationViewModel
    {
        private ServiceClientManager _serviceClientManager;

        public IEffectController EffectController { get; private set; }

        public ICommand CancelCommand { get; private set; }

        public WaitingForGameViewModel(INavigationService navigationService, IEffectController effectController, ServiceClientManager serviceClientManager) : base(navigationService)
        {
            EffectController = effectController;

            CancelCommand = new DelegateCommand(CancelCommandExecute);

            _serviceClientManager = serviceClientManager;
            _serviceClientManager.GameServiceClient.Callback.GameReceived += CallbackBoardReceived;
        }

        private void CallbackBoardReceived(object sender, GameReceivedEventArgs e)
        {
            _serviceClientManager.GameServiceClient.Callback.GameReceived -= CallbackBoardReceived;
            NavigateTo(NavigationIndex.Game, e.Game);
        }

        private void CancelCommandExecute()
        {
            _serviceClientManager.GameServiceClient.StopLookingForQuickGame();

            GoBack();
        }
    }
}
