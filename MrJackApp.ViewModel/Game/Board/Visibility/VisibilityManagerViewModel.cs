using MrJackApp.ViewModel.Common;

namespace MrJackApp.ViewModel.Game.Board.Visibility
{
    public sealed class VisibilityManagerViewModel : BindableBase
    {
        private bool _isTurnSchedulerDisplayable;
        public bool IsTurnSchedulerDisplayable
        {
            get { return _isTurnSchedulerDisplayable; }
            set { SetProperty(ref _isTurnSchedulerDisplayable, value); }
        }

        private bool _isTilesDisplayerDisplayable;
        public bool IsTilesDisplayerDisplayable
        {
            get { return _isTilesDisplayerDisplayable; }
            set { SetProperty(ref _isTilesDisplayerDisplayable, value); }
        }

        private bool _isCharactersDisplayerDisplayable;
        public bool IsCharactersDisplayerDisplayable
        {
            get { return _isCharactersDisplayerDisplayable; }
            set { SetProperty(ref _isCharactersDisplayerDisplayable, value); }
        }

        private bool _isJackIdentityDisplayable;
        public bool IsJackIdentityDisplayable
        {
            get { return _isJackIdentityDisplayable; }
            set { SetProperty(ref _isJackIdentityDisplayable, value); }
        }

        private bool _isJackVisibilityDisplayable;
        public bool IsJackVisibilityDisplayable
        {
            get { return _isJackVisibilityDisplayable; }
            set { SetProperty(ref _isJackVisibilityDisplayable, value); }
        }

        public VisibilityManagerViewModel() : base()
        {
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            IsTurnSchedulerDisplayable = false;
            IsTilesDisplayerDisplayable = false;
            IsCharactersDisplayerDisplayable = false;
            IsJackIdentityDisplayable = false;
            IsJackVisibilityDisplayable = false;
        }
    }
}
