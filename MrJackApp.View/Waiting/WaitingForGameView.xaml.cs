using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MrJackApp.View.Waiting
{
    /// <summary>
    /// Logique d'interaction pour WaitingForGameView.xaml
    /// </summary>
    public partial class WaitingForGameView : UserControl
    {
        private DispatcherTimer _timer;
        private int _currentChildrenIndex = -1;
        private int _ellipseCount = 20;

        public WaitingForGameView()
        {
            InitializeComponent();
            Loaded += WaitingForGameViewLoaded;
        }

        private void WaitingForGameViewLoaded(object sender, RoutedEventArgs e)
        {
            AddChildren();

            StartTimer();
        }

        private void AddChildren()
        {
            for (int i = 0; i < _ellipseCount; i++)
                WaitingStackPanel.Children.Add(
                    new Ellipse {
                        Width = 10
                        , Height = 10
                        , Fill = new SolidColorBrush(Colors.Black)
                        , Margin = new Thickness(5, 0, 5, 0)
                        , RenderTransformOrigin = new Point(0.5, 0.5)
                        , RenderTransform = new ScaleTransform() }
                    );
        }

        private void StartTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 250);
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        private void TimerTick(object sender, object e)
        {
            if (_currentChildrenIndex == WaitingStackPanel.Children.Count - 1)
                _currentChildrenIndex = 0;
            else
                _currentChildrenIndex++;

            var duration = new Duration(new TimeSpan(0, 0, 0, 0, 200));
            var unscaleAnimation = new DoubleAnimation(1, duration);
            var scaleAnimation = new DoubleAnimation(1.5, duration);

            if (_currentChildrenIndex > 0)
                UnscaleElement(WaitingStackPanel.Children[_currentChildrenIndex - 1]);
            else
                UnscaleElement(WaitingStackPanel.Children[WaitingStackPanel.Children.Count - 1]);

            ScaleElement(WaitingStackPanel.Children[_currentChildrenIndex]);
        }

        private void ScaleElement(DependencyObject element)
        {
            ScaleElement(element, 1.5);
        }

        private void UnscaleElement(DependencyObject element)
        {
            ScaleElement(element, 1.0);
        }

        private void ScaleElement(DependencyObject element, double value)
        {
            var storyboard = new Storyboard();

            var duration = new Duration(new TimeSpan(0, 0, 0, 0, 200));
            var scaleXAnimation = new DoubleAnimation(value, duration);
            var scaleYAnimation = new DoubleAnimation(value, duration);

            storyboard.Children.Add(scaleXAnimation);
            storyboard.Children.Add(scaleYAnimation);

            Storyboard.SetTargetProperty(scaleXAnimation, new PropertyPath("RenderTransform.ScaleX"));
            Storyboard.SetTargetProperty(scaleYAnimation, new PropertyPath("RenderTransform.ScaleY"));
            Storyboard.SetTarget(scaleXAnimation, element);
            Storyboard.SetTarget(scaleYAnimation, element);

            storyboard.Begin();
        }
    }
}
