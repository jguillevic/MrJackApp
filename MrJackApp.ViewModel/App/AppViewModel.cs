using MrJackApp.DTO.Game.Board;
using MrJackApp.ViewModel.Common;
using MrJackApp.ViewModel.Common.Navigation;
using MrJackApp.ViewModel.Game.Board;
using MrJackApp.ViewModel.MainMenu;
using MrJackApp.ViewModel.Waiting;
using MrJackApp.WCFContract.Game;
using MrJackApp.WCFServiceClient.Game;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MrJackApp.ViewModel.App
{
    public sealed class AppViewModel : BindableBase, INavigationService
    {
        private GameServiceClient _gameServiceClient = new GameServiceClient("ConfigClient");

        private object _currentViewModel;
        public object CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        private List<object> _previousViewModels = new List<object>();

        public AppViewModel() : base() { }

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
            _previousViewModels.Add(CurrentViewModel);

            switch (index)
            {
                case NavigationIndex.MainMenu:
                    CurrentViewModel = new MainMenuViewModel(this);
                    break;
                case NavigationIndex.WaitingForGame:
                    var viewModel = new WaitingForGameViewModel(this, _gameServiceClient);
                    CurrentViewModel = viewModel;
                    break;
                case NavigationIndex.About:
                    break;
                case NavigationIndex.Game:
                    CurrentViewModel = new BoardViewModel((BoardDTO)parameter, this);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
