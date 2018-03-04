using MrJackApp.Service.Navigation;
using MrJackApp.Service.Sound.Effect;
using MrJackApp.Service.Sound.Music;
using MrJackApp.ViewModel.Common.Command;
using MrJackApp.ViewModel.Common.Navigation;
using System.Windows.Input;

namespace MrJackApp.ViewModel.Setting
{
    public sealed class SettingsViewModel : NavigationViewModel
    {
        private double _musicVolumeInitValue;
        private bool _isMusicActivatedInitValue;
        private double _effectVolumeInitValue;
        private bool _isEffectActivatedInitValue;
        private bool _isMusicSettingsModified;
        private bool _isEffectSettingsModified;

        private IMusicController _musicController;

        public IEffectController EffectController { get; private set; }

        public double MusicVolume
        {
            get { return _musicController.GetVolume(); }
            set
            {             
                _musicController.SetVolume(value);
                _isMusicSettingsModified = true;
                RaisePropertyChanged("MusicVolume");
            }
        }

        public bool IsMusicActivated
        {
            get { return !_musicController.IsMute(); }
            set
            {
                if (value)
                    _musicController.Unmute();
                else
                    _musicController.Mute();

                _isMusicSettingsModified = true;
                RaisePropertyChanged("IsMusicActivated");
            }
        }

        public double EffectVolume
        {
            get { return EffectController.GetVolume(); }
            set
            {
                EffectController.SetVolume(value);
                _isEffectSettingsModified = true;
                RaisePropertyChanged("EffectVolume");
            }
        }

        public bool IsEffectActivated
        {
            get { return !EffectController.IsMute(); }
            set
            {
                if (value)
                    EffectController.Unmute();
                else
                    EffectController.Mute();

                _isEffectSettingsModified = true;
                RaisePropertyChanged("IsEffectActivated");
            }
        }

        public ICommand ValidateCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public SettingsViewModel(INavigationService navigationService, IMusicController musicController, IEffectController effectController) : base(navigationService)
        {
            _musicController = musicController;
            EffectController = effectController;

            StoreInitialValues();

            CancelCommand = new DelegateCommand(CancelCommandExecute);
            ValidateCommand = new DelegateCommand(ValidateCommandExecute);
        }

        private void CancelCommandExecute()
        {
            RestoreInitialValues();

            GoBack();
        }

        private void ValidateCommandExecute()
        {
            if (_isMusicSettingsModified)
                _musicController.Save();
            if (_isEffectSettingsModified)
                EffectController.Save();

            GoBack();
        }

        private void StoreInitialValues()
        {
            _musicVolumeInitValue = MusicVolume;
            _isMusicActivatedInitValue = IsMusicActivated;
            _effectVolumeInitValue = EffectVolume;
            _isEffectActivatedInitValue = IsEffectActivated;
        }

        private void RestoreInitialValues()
        {
            MusicVolume = _musicVolumeInitValue;
            IsMusicActivated = _isMusicActivatedInitValue;
            EffectVolume = _effectVolumeInitValue;
            IsEffectActivated = _isEffectActivatedInitValue;
        }
    }
}
