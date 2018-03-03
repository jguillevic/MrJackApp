using MrJackApp.Service.Sound.Effect;
using MrJackApp.ViewModel.Common;
using System;

namespace MrJackApp.ViewModel.Sound.effect
{
    public sealed class EffectPlayerViewModel : BindableBase, IEffectController
    {
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

        public EffectPlayerViewModel() : base() { }

        public void Play(int effectIndex)
        {
            IsPlaying = false;

            Position = TimeSpan.FromMilliseconds(0.0);

            switch (effectIndex)
            {
                case EffectIndex.ButtonPointerOver:
                    break;
                default:
                    throw new NotImplementedException();
            }

            IsPlaying = true;
        }

        public void SetVolume(double volume)
        {
            Volume = volume;
        }

        public void Play()
        {
            IsPlaying = true;
        }

        public void Stop()
        {
            IsPlaying = false;
        }
    }
}
