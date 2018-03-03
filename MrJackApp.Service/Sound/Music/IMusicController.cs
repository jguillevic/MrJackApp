namespace MrJackApp.Service.Sound.Music
{
    public interface IMusicController
    {
        void Play(int musicIndex);
        void Play();
        void Stop();
        void SetVolume(double volume);
    }
}
