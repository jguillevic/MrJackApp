using MrJackApp.Service.Sound.Effect;
using MrJackApp.ViewModel.Common.Command;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MrJackApp.View.Common.Component.Button
{
    /// <summary>
    /// Logique d'interaction pour MenuButton.xaml
    /// </summary>
    public partial class MenuButton : UserControl
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MenuButton));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(MenuButton));
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        internal bool IsClicked
        {
            get { return (bool)GetValue(IsClickedProperty); }
            set { SetValue(IsClickedProperty, value); }
        }
        internal static readonly DependencyProperty IsClickedProperty =
            DependencyProperty.Register("IsClicked", typeof(bool), typeof(MenuButton), new PropertyMetadata(false));

        internal ICommand ClickCommand
        {
            get { return (ICommand)GetValue(ClickCommandProperty); }
            set { SetValue(ClickCommandProperty, value); }
        }     
        internal static readonly DependencyProperty ClickCommandProperty =
            DependencyProperty.Register("ClickCommand", typeof(ICommand), typeof(MenuButton), new PropertyMetadata(null));

        internal ICommand UnclickCommand
        {
            get { return (ICommand)GetValue(UnclickCommandProperty); }
            set { SetValue(UnclickCommandProperty, value); }
        }
        internal static readonly DependencyProperty UnclickCommandProperty =
            DependencyProperty.Register("UnclickCommand", typeof(ICommand), typeof(MenuButton), new PropertyMetadata(null));

        internal ICommand PointerOverCommand
        {
            get { return (ICommand)GetValue(PointerOverCommandProperty); }
            set { SetValue(PointerOverCommandProperty, value); }
        }    
        internal static readonly DependencyProperty PointerOverCommandProperty =
            DependencyProperty.Register("PointerOverCommand", typeof(ICommand), typeof(MenuButton), new PropertyMetadata(null));

        public IEffectController EffectController
        {
            get { return (IEffectController)GetValue(EffectControllerProperty); }
            set { SetValue(EffectControllerProperty, value); }
        }       
        public static readonly DependencyProperty EffectControllerProperty =
            DependencyProperty.Register("EffectController", typeof(IEffectController), typeof(MenuButton), new PropertyMetadata(null));

        public MenuButton()
        {
            InitializeComponent();

            ClickCommand = new DelegateCommand(ClickCommandExecute);
            UnclickCommand = new DelegateCommand(UnclikCommandExecute);
            PointerOverCommand = new DelegateCommand(PointerOverCommandExecute);
        }

        private void ClickCommandExecute()
        {
            if (EffectController != null)
                EffectController.Play(EffectIndex.MenuButtonClicked);

            IsClicked = true;
        }

        private void UnclikCommandExecute()
        {
            IsClicked = false;
        }

        private void PointerOverCommandExecute()
        {
            if (EffectController != null)
                EffectController.Play(EffectIndex.MenuButtonPointerOver);
        }
    }
}
