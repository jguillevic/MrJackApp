using MrJackApp.DTO.Game.Board;
using MrJackApp.ViewModel.Common;
using MrJackApp.ViewModel.Common.Navigation;
using MrJackApp.ViewModel.Game.Board;
using MrJackApp.ViewModel.MainMenu;
using MrJackApp.ViewModel.RuleBook;
using MrJackApp.ViewModel.Waiting;
using MrJackApp.WCFServiceClient.Game;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MrJackApp.ViewModel.App
{
    public sealed class AppViewModel : BindableBase, INavigationService
    {
        private ServiceClientManager _serviceClientManager = new ServiceClientManager();
        private List<object> _previousViewModels = new List<object>();

        private object _currentViewModel;
        public object CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public AppViewModel() : base() { }

        public void Initialize()
        {
            _serviceClientManager.OpenSession();
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
                    CurrentViewModel = new MainMenuViewModel(this, _serviceClientManager);
                    break;
                case NavigationIndex.WaitingForGame:
                    CurrentViewModel = new WaitingForGameViewModel(this, _serviceClientManager);
                    break;
                case NavigationIndex.About:
                    break;
                case NavigationIndex.Game:
                    CurrentViewModel = new BoardViewModel((BoardDTO)parameter, this);
                    break;
                case NavigationIndex.RuleBook:
                    CurrentViewModel = new RuleBookDisplayerViewModel(this);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
