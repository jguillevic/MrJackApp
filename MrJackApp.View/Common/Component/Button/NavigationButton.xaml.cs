using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MrJackApp.View.Common.Component.Button
{
    /// <summary>
    /// Interaction logic for NavigationButton.xaml
    /// </summary>
    public sealed partial class NavigationButton : UserControl
    {
        public Dictionary<NavigationButtonDirection, string> Data { get; } = new Dictionary<NavigationButtonDirection, string>();

        public NavigationButtonDirection Direction
        {
            get { return (NavigationButtonDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(NavigationButtonDirection), typeof(NavigationButton), new PropertyMetadata(NavigationButtonDirection.Left, RaiseDirectionPropertyChanged));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(NavigationButton), new PropertyMetadata(null, RaiseCommandPropertyChanged));

        public bool CanExecute
        {
            get { return (bool)GetValue(CanExecuteProperty); }
            set { SetValue(CanExecuteProperty, value); }
        }

        public static readonly DependencyProperty CanExecuteProperty =
            DependencyProperty.Register("CanExecute", typeof(bool), typeof(NavigationButton), new PropertyMetadata(false));

        public NavigationButton()
        {
            InitializeComponent();

            Data.Add(NavigationButtonDirection.Left, "M 5 25 L 38 10 L 38 40");
            Data.Add(NavigationButtonDirection.Right, "M 45 25 L 12 10 L 12 40");
        }

        private static void RaiseCommandPropertyChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            var navigationButton = (NavigationButton)sender;

            if (args.OldValue != null)
                ((ICommand)args.OldValue).CanExecuteChanged -= navigationButton.CommandCanExecuteChanged;

            if (args.NewValue != null)
            {
                var command = (ICommand)args.NewValue;
                command.CanExecuteChanged += navigationButton.CommandCanExecuteChanged;
                navigationButton.CanExecute = command.CanExecute(null);
            }
        }

        public void CommandCanExecuteChanged(object sender, System.EventArgs e)
        {
            var command = sender as ICommand;
            CanExecute = command.CanExecute(null);
        }

        private static void RaiseDirectionPropertyChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            var navigationButton = (NavigationButton)sender;

            SetGeometry((NavigationButton)sender, (NavigationButtonDirection)args.NewValue);
        }

        private static void SetGeometry(NavigationButton navBut, NavigationButtonDirection direction)
        {
            navBut.ArrowPath.Data = Geometry.Parse(navBut.Data[direction]);
        }
    }
}
