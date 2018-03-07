using System;
using System.Windows;

namespace MrJackApp.View.Common.Extension.MediaElement
{
    public static class MediaElementExtension
    {
        public static TimeSpan GetPosition(DependencyObject obj)
        {
            return (TimeSpan)obj.GetValue(PositionProperty);
        }

        public static void SetPosition(DependencyObject obj, TimeSpan value)
        {
            obj.SetValue(PositionProperty, value);
        }
        
        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.RegisterAttached("Position", typeof(TimeSpan), typeof(MediaElementExtension), new PropertyMetadata(new TimeSpan(), PositionChangedCallback));

        private static void PositionChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var mediaElement = d as System.Windows.Controls.MediaElement;
            if (mediaElement == null)
                return;

            mediaElement.Position = (TimeSpan)e.NewValue;
        }

        public static DependencyProperty IsPlayingProperty =
            DependencyProperty.RegisterAttached("IsPlaying", typeof(bool), typeof(MediaElementExtension), new PropertyMetadata(false, IsPlayingChangedCallback));

        public static bool GetIsPlaying(DependencyObject d)
        {
            return (bool)d.GetValue(IsPlayingProperty);
        }

        public static void SetIsPlaying(DependencyObject d, bool value)
        {
            d.SetValue(IsPlayingProperty, value);
        }

        private static void IsPlayingChangedCallback(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var mediaElement = obj as System.Windows.Controls.MediaElement;

            if (mediaElement == null)
                return;

            bool isPlaying = (bool)args.NewValue;
            if (isPlaying)
                mediaElement.Play();
            else
                mediaElement.Stop();
        }
    }
}
