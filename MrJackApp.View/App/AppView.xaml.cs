using MrJackApp.ViewModel.App;
using MrJackApp.ViewModel.Common.Navigation;
using System.Windows.Controls;

namespace MrJackApp.View.App
{
    /// <summary>
    /// Logique d'interaction pour AppView.xaml
    /// </summary>
    public partial class AppView : UserControl
    {
        public AppView()
        {
            InitializeComponent();

            Loaded += AppViewLoaded;
        }

        private void AppViewLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Loaded -= AppViewLoaded;

            var viewModel = new AppViewModel();
            viewModel.Initialize();
            viewModel.NavigateTo(NavigationIndex.MainMenu);
            DataContext = viewModel;
        }
    }
}
