using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MrJackApp.View.RuleBook
{
    /// <summary>
    /// Logique d'interaction pour RuleBookDisplayerView.xaml
    /// </summary>
    public partial class RuleBookDisplayerView : UserControl
    {
        private double _currentZoomFactor = 1.0;

        public double CenterX
        {
            get { return (double)GetValue(CenterXProperty); }
            set { SetValue(CenterXProperty, value); }
        }

        public static readonly DependencyProperty CenterXProperty =
            DependencyProperty.Register("CenterX", typeof(double), typeof(RuleBookDisplayerView), new PropertyMetadata(0.5));

        public double CenterY
        {
            get { return (double)GetValue(CenterYProperty); }
            set { SetValue(CenterYProperty, value); }
        }

        public static readonly DependencyProperty CenterYProperty =
            DependencyProperty.Register("CenterY", typeof(double), typeof(RuleBookDisplayerView), new PropertyMetadata(0.5));

        public double ScaleX
        {
            get { return (double)GetValue(ScaleXProperty); }
            set { SetValue(ScaleXProperty, value); }
        }

        public static readonly DependencyProperty ScaleXProperty =
            DependencyProperty.Register("ScaleX", typeof(double), typeof(RuleBookDisplayerView), new PropertyMetadata(1.0));

        public double ScaleY
        {
            get { return (double)GetValue(ScaleYProperty); }
            set { SetValue(ScaleYProperty, value); }
        }

        public static readonly DependencyProperty ScaleYProperty =
            DependencyProperty.Register("ScaleY", typeof(double), typeof(RuleBookDisplayerView), new PropertyMetadata(1.0));

        public RuleBookDisplayerView()
        {
            InitializeComponent();

            Loaded += RuleBookDisplayerViewLoaded;
        }

        private void RuleBookDisplayerViewLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= RuleBookDisplayerViewLoaded;

            UserControl.SizeChanged += UserControlSizeChanged;

            SetScale(1.0);
        }

        private void SetScale(double scaleRate)
        {
            if (_currentZoomFactor * scaleRate >= 1.0)
            {
                _currentZoomFactor *= scaleRate;
                var scaleX = _currentZoomFactor * (ScrollViewer.ActualWidth - 10) / Image.ActualWidth;
                var scaleY = _currentZoomFactor * (ScrollViewer.ActualHeight - 10) / Image.ActualHeight;
                var scale = Math.Min(scaleX, scaleY);
                ScaleX = scale;
                ScaleY = scale;
            }
        }

        private void SetCenter(double posX, double posY)
        {
            CenterX = posX / Image.ActualWidth;
            CenterY = posY / Image.ActualHeight;
        }

        private void ImageMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var pos = e.GetPosition(Image);
            SetCenter(pos.X, pos.Y);

            if (e.Delta > 0)
            {
                SetScale(1.1);
            }
            else
            {
                SetScale(1 / 1.1);
            }

            e.Handled = true;
        }

        private void UserControlSizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetScale(1.0);
        }
    }
}
