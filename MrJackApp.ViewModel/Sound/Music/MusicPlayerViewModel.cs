using MrJackApp.Serialization.Json;
using MrJackApp.Service.Sound.Music;
using MrJackApp.ViewModel.Common;
using MrJackApp.ViewModel.Common.Command;
using System;
using System.IO;
using System.Windows.Input;

namespace MrJackApp.ViewModel.Sound.Music
{
    public sealed class MusicPlayerViewModel : BindableBase, IMusicController
    {
        private const string MusicSettingsFilePath = "MusicSettings.json";

        private bool _isMute;
        private int _currentMusicIndex;

        private double _volume;
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

        private bool _isPlaying;
        public bool IsPlaying
        {
            get { return _isPlaying; }
            set { SetProperty(ref _isPlaying, value); }
        }
        
        public ICommand RepeatCommand { get; private set; }

        public MusicPlayerViewModel() : base()
        {
            RepeatCommand = new DelegateCommand(RepeatCommandExecute);
        }

        public void Play(int musicIndex)
        {
            if (!_isMute)
            {
                _currentMusicIndex = musicIndex;

                IsPlaying = false;

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
        }

        public void SetVolume(double volume)
        {
            Volume = volume;
        }

        public double GetVolume()
        {
            return Volume;
        }

        public void Stop()
        {
            IsPlaying = false;
        }

        public void Mute()
        {
            _isMute = true;

            if (IsPlaying)
                Stop();
        }

        public void Unmute()
        {
            _isMute = false;

            if (!IsPlaying)
                Play(_currentMusicIndex);
        }

        public bool IsMute()
        {
            return _isMute;
        }

        public void Save()
        {
            var settings = CreateAndMapToMusicSettings();

            using (var fs = new FileStream(MusicSettingsFilePath, FileMode.Create))
            {
                var jsonSer = new JsonSerializer() { OutputStream = fs, InputData = settings };
                jsonSer.Serialize();
            }
        }

        public void Initialize()
        {
            if (HasDataToLoad())
                Load();
            else
            {
                SetDefaultValues();
                Save();
            }

            Play(MusicIndex.MainTheme);
        }

        private void Load()
        {
            MusicSettings settings = null;

            using (var fs = new FileStream(MusicSettingsFilePath, FileMode.Open))
            {
                var jsonDeser = new JsonDeserializer<MusicSettings>() { InputStream = fs };
                jsonDeser.Deserialize();
                settings = jsonDeser.OutputData;
            }

            MapFromMusicSettings(settings);
        }

        private bool HasDataToLoad()
        {
            return File.Exists(MusicSettingsFilePath);
        }

        private void SetDefaultValues()
        {
            _isMute = false;
            Volume = 0.5;
        }

        private void RepeatCommandExecute()
        {
            Play(_currentMusicIndex);
        }

        private MusicSettings CreateAndMapToMusicSettings()
        {
            return new MusicSettings() { IsMute = _isMute, Volume = Volume };
        }

        private void MapFromMusicSettings(MusicSettings settings)
        {
            _isMute = settings.IsMute;
            Volume = settings.Volume;
        }
    }
}
