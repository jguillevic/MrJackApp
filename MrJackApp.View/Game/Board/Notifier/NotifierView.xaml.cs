using MrJackApp.ViewModel.Game.Board.Notifier;
using System;
using System.Windows.Controls;

namespace MrJackApp.View.Game.Board.Notifier
{
    /// <summary>
    /// Logique d'interaction pour NotifierView.xaml
    /// </summary>
    public partial class NotifierView : UserControl
    {
        public NotifierView()
        {
            InitializeComponent();
        }

        private void StoryboardCompleted(object sender, EventArgs e)
        {
            var viewModel = (NotifierViewModel)DataContext;
            viewModel.NextMessageCommand.Execute(null);
        }
    }
}
