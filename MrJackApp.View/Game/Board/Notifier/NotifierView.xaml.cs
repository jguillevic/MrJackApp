using MrJackApp.ViewModel.Game.Board.Notifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void TextBlockTargetUpdated(object sender, DataTransferEventArgs e)
        {
            var textBlock = (TextBlock)sender;
            if (textBlock.Text == null)
                e.Handled = true;
        }
    }
}
