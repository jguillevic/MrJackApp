using MrJackApp.Service.Navigation;

namespace MrJackApp.ViewModel.Common.Navigation
{
    public abstract class NavigationViewModel : BindableBase
    {
        private INavigationService _navigationService;

        public NavigationViewModel(INavigationService navigationService) : base()
        {
            _navigationService = navigationService;
        }

        protected void NavigateTo(int index)
        {
            _navigationService.NavigateTo(index);
        }

        protected void NavigateTo(int index, object parameters)
        {
            _navigationService.NavigateTo(index, parameters);
        }

        protected void GoBack()
        {
            _navigationService.GoBack();
        }
    }
}
