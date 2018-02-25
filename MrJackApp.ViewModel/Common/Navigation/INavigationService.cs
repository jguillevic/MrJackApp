namespace MrJackApp.ViewModel.Common.Navigation
{
    public interface INavigationService
    {
        void GoBack();

        void NavigateTo(int index);

        void NavigateTo(int index, object parameter);
    }
}
