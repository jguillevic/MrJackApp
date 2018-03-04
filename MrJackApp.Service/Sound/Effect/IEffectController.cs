namespace MrJackApp.Service.Sound.Effect
{
    public interface IEffectController
    {
        void Play(int effectIndex);
        void Stop();
        void SetVolume(double volume);
        double GetVolume();
        void Mute();
        void Unmute();
        bool IsMute();
        void Save();
    }
}
