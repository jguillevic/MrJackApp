using MrJackApp.Service.Sound.Music;
using MrJackApp.ViewModel.Common;
using MrJackApp.ViewModel.Common.Command;
using System;
using System.Windows.Input;

namespace MrJackApp.ViewModel.Sound.Music
{
    public sealed class MusicPlayerViewModel : BindableBase, IMusicController
    {
        private int _currentMusicIndex;

        private double _volume = 0.5;
        public double Volume
        {
            get { return _volume; }
            set { SetProperty(ref _volume, value); }
        }

        private string _source;
        public string Source
        {
            get { return _source; }
            set { SetProperty(ref _source, value); }
        }

        private TimeSpan _position;
        public TimeSpan Position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
        }

        private bool _isPlaying;
        public bool IsPlaying
        {
            get { return _isPlaying; }
            set { SetProperty(ref _isPlaying, value); }
        }

        public ICommand InitialPlayCommand { get; private set; }
        public ICommand RepeatCommand { get; private set; }

        public MusicPlayerViewModel() : base()
        {
            InitialPlayCommand = new DelegateCommand(InitialPlayCommandExecute);
            RepeatCommand = new DelegateCommand(RepeatCommandExecute);
        }

        public void Play(int musicIndex)
        {
            _currentMusicIndex = musicIndex;

            IsPlaying = false;

            Position = TimeSpan.FromMilliseconds(0.0);

            switch (musicIndex)
            {
                case MusicIndex.MainTheme:
                    Source = "Sound/Music/MainTheme.mp3";
                    break;
                default:
                    throw new NotImplementedException();
            }

            IsPlaying = true;
        }

        public void Play()
        {
            IsPlaying = true;
        }

        public void SetVolume(double volume)
        {
            Volume = volume;
        }

        public void Stop()
        {
            IsPlaying = false;
        }

        private void InitialPlayCommandExecute()
        {
            Play(MusicIndex.MainTheme);
        }

        private void RepeatCommandExecute()
        {
            Play(_currentMusicIndex);
        }
    }
}
