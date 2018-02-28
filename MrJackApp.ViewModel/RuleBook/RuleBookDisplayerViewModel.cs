using MrJackApp.ViewModel.Common.Command;
using MrJackApp.ViewModel.Common.Navigation;
using System.Globalization;
using System.Windows.Input;

namespace MrJackApp.ViewModel.RuleBook
{
    public sealed class RuleBookDisplayerViewModel : NavigationViewModel
    {
        private string _pagePathPattern = "pack://application:,,,/MrJackApp.Resource;component/Image/RuleBook/MrJack_RuleBook_{0}.png";

        private int _minPageIndex = 0;
        private int _maxPageIndex = 11;
        private int _currentPageIndex;

        private string _currentPagePath;
        public string CurrentPagePath
        {
            get { return _currentPagePath; }
            set { SetProperty(ref _currentPagePath, value); }
        }

        public DelegateCommand MoveToPreviousPageCommand { get; private set; }
        public DelegateCommand MoveToNextPageCommand { get; private set; }
        public ICommand GoBackCommand { get; private set; }

        public RuleBookDisplayerViewModel(INavigationService navigationService) : base(navigationService)
        {
            MoveToPreviousPageCommand = new DelegateCommand(MoveToPreviousPageCommandExecute, MoveToPreviousPageCommandCanExecute);
            MoveToNextPageCommand = new DelegateCommand(MoveToNextPageCommandExecute, MoveToNextPageCommandCanExecute);
            GoBackCommand = new DelegateCommand(GoBackCommandExecute);

            _currentPageIndex = _minPageIndex;
            SetCurrentPagePath();
        }

        private void SetCurrentPagePath()
        {
            CurrentPagePath = string.Format(CultureInfo.InvariantCulture, _pagePathPattern, _currentPageIndex);
        }

        private void MoveToPreviousPageCommandExecute()
        {
            _currentPageIndex--;
            SetCurrentPagePath();
            MoveToPreviousPageCommand.RaiseCanExecuteChanged();
            MoveToNextPageCommand.RaiseCanExecuteChanged();
        }

        private bool MoveToPreviousPageCommandCanExecute()
        {
            return _currentPageIndex > _minPageIndex;
        }

        private void MoveToNextPageCommandExecute()
        {
            _currentPageIndex++;
            SetCurrentPagePath();
            MoveToPreviousPageCommand.RaiseCanExecuteChanged();
            MoveToNextPageCommand.RaiseCanExecuteChanged();
        }

        private bool MoveToNextPageCommandCanExecute()
        {
            return _currentPageIndex < _maxPageIndex;
        }

        private void GoBackCommandExecute()
        {
            GoBack();
        }
    }
}
