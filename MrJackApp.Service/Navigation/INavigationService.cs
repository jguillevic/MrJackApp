namespace MrJackApp.Service.Navigation
{
    public interface INavigationService
    {
        void GoBack();

        void NavigateTo(int index);

        void NavigateTo(int index, object parameter);
    }
}
