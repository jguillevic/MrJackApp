using MrJackApp.Service.App;
using MrJackApp.Service.Navigation;
using MrJackApp.ViewModel.App;
using System.Windows;

namespace MrJackApp.UI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IAppService
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
