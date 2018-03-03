namespace MrJackApp.Service.Sound.Effect
{
    public interface IEffectController
    {
        void Play(int effectIndex);
        void Play();
        void Stop();
        void SetVolume(double volume);
    }
}
