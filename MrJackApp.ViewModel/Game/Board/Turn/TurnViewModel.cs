using MrJackApp.DTO.Game.Board.Turn;
using MrJackApp.ViewModel.Common;

namespace MrJackApp.ViewModel.Game.Board.Turn
{
    public sealed class TurnViewModel : BindableBase
    {
        public int Value { get; set; }
        private bool _isCurrent;
        public bool IsCurrent
        {
            get { return _isCurrent; }
            set { SetProperty(ref _isCurrent, value); }
        }

        public TurnViewModel(TurnDTO turn) : base()
        {
            Map(turn);
        }

        private void Map(TurnDTO turn)
        {
            Value = turn.Value;
            IsCurrent = turn.IsCurrent;
        }
    }
}
