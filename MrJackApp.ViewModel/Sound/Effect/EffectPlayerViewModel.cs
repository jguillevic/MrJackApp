using MrJackApp.Service.Sound.Effect;
using MrJackApp.ViewModel.Common;
using MrJackApp.ViewModel.Common.Command;
using System;
using System.Windows.Input;

namespace MrJackApp.ViewModel.Sound.effect
{
    public sealed class EffectPlayerViewModel : BindableBase, IEffectController
    {
        private bool _isMute;

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

        public EffectPlayerViewModel() : base() { }

        public void Play(int effectIndex)
        {
            if (!_isMute)
            {
                IsPlaying = false;

                switch (effectIndex)
                {
                    case EffectIndex.MenuButtonPointerOver:
                        Source = "Sound/Effect/Button/MenuButtonPointerOver.mp3";
                        break;
                    case EffectIndex.MenuButtonClicked:
                        Source = "Sound/Effect/Button/MenuButtonClicked.mp3";
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

        public void Stop()
        {
            if (!_isMute)
                IsPlaying = false;
        }

        public double GetVolume()
        {
            return Volume;
        }

        public void Mute()
        {
            _isMute = true;
        }

        public void Unmute()
        {
            _isMute = false;
        }

        public bool IsMute()
        {
            return _isMute;
        }

        public void Save()
        {
            
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
        }

        private void Load()
        {

        }

        private bool HasDataToLoad()
        {
            return false;
        }

        private void SetDefaultValues()
        {
            _isMute = false;
            Volume = 0.5;
        }
    }
}
