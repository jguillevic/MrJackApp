namespace MrJackApp.ViewModel.Common
{
    public sealed class CoordinateViewModel : BindableBase
    {
        public int X { get; set; }
        public int Y { get; set; }

        public CoordinateViewModel(int x, int y) : base()
        {
            X = x;
            Y = y;
        }
    }
}
