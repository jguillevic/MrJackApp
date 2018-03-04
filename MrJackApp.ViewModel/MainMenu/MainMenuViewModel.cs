﻿using MrJackApp.Service.Navigation;
using MrJackApp.Service.Sound.Effect;
using MrJackApp.ViewModel.About;
using MrJackApp.ViewModel.Common.Navigation;
using MrJackApp.WCFServiceClient.Game;
using System.Collections.Generic;

namespace MrJackApp.ViewModel.MainMenu
{
    public sealed class MainMenuViewModel : NavigationViewModel
    {
        public AboutViewModel AboutViewModel { get; } = new AboutViewModel();
        public List<MainMenuItemViewModel> Menus { get; } = new List<MainMenuItemViewModel>();

        public MainMenuViewModel(INavigationService navigationService, IEffectController effectController, ServiceClientManager serviceClientManager) : base(navigationService)
        {
            Menus.Add(new QuickGameMenuItemViewModel(navigationService, effectController, serviceClientManager));
            Menus.Add(new RuleBookMenuItemViewModel(navigationService, effectController));
            Menus.Add(new SettingsMenuItemViewModel(navigationService, effectController));
        }
    }
}
