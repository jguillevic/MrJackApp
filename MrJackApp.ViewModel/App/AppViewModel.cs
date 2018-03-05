using MrJackApp.DTO.Game.Board;
using MrJackApp.Service.App;
using MrJackApp.Service.Navigation;
using MrJackApp.Service.Sound.Effect;
using MrJackApp.ViewModel.Common;
using MrJackApp.ViewModel.Game.Board;
using MrJackApp.ViewModel.MainMenu;
using MrJackApp.ViewModel.RuleBook;
using MrJackApp.ViewModel.Setting;
using MrJackApp.ViewModel.Sound.effect;
using MrJackApp.ViewModel.Sound.Music;
using MrJackApp.ViewModel.Waiting;
using MrJackApp.WCFServiceClient.Game;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MrJackApp.ViewModel.App
{
    public sealed class AppViewModel : BindableBase, INavigationService
    {
        private IAppService _appService;

        public EffectPlayerViewModel EffectPlayerViewModel { get; private set; } = new EffectPlayerViewModel();
        public MusicPlayerViewModel MusicPlayerViewModel { get; private set; } = new MusicPlayerViewModel();

        private ServiceClientManager _serviceClientManager = new ServiceClientManager();
        private List<object> _previousViewModels = new List<object>();

        private object _currentViewModel;
        public object CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public AppViewModel(IAppService appService) : base()
        {
            _appService = appService;
        }

        public void Initialize()
        {
            _serviceClientManager.OpenSession();

            EffectPlayerViewModel.Initialize();
            MusicPlayerViewModel.Initialize();
        }

        public void GoBack()
        {
            if (_previousViewModels.Any())
            {
                var previousViewModel = _previousViewModels.Last();
                _previousViewModels.RemoveAt(_previousViewModels.Count - 1);
                CurrentViewModel = previousViewModel;
            }
        }

        public void NavigateTo(int index)
        {
            NavigateTo(index, null);
        }

        public void NavigateTo(int index, object parameter)
        {
            if (CurrentViewModel != null)
                _previousViewModels.Add(CurrentViewModel);

            switch (index)
            {
                case NavigationIndex.MainMenu:
                    CurrentViewModel = new MainMenuViewModel(this, EffectPlayerViewModel, _serviceClientManager);
                    break;
                case NavigationIndex.WaitingForGame:
                    CurrentViewModel = new WaitingForGameViewModel(this, _serviceClientManager);
                    break;
                case NavigationIndex.Game:
                    CurrentViewModel = new BoardViewModel((BoardDTO)parameter, this);
                    break;
                case NavigationIndex.RuleBook:
                    CurrentViewModel = new RuleBookDisplayerViewModel(this);
                    break;
                case NavigationIndex.Settings:
                    CurrentViewModel = new SettingsViewModel(this, MusicPlayerViewModel, EffectPlayerViewModel);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
