namespace MrJackApp.Service.Sound.Music
{
    public interface IMusicController
    {
        void Play(int musicIndex);
        void Stop();
        void SetVolume(double volume);
        double GetVolume();
        void Mute();
        void Unmute();
        bool IsMute();
        void Save();
    }
}
