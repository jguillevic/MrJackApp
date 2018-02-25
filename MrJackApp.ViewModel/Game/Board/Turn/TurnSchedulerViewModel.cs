using MrJackApp.DTO.Game.Board.Turn;
using MrJackApp.ViewModel.Common;
using System;

namespace MrJackApp.ViewModel.Game.Board.Turn
{
    public sealed class TurnSchedulerViewModel : BindableBase
    {
        private TurnViewModel[] _turns;
        public TurnViewModel[] Turns
        {
            get { return _turns; }
            set { SetProperty(ref _turns, value); }
        }

        private TurnViewModel _currentTurn;

        public TurnSchedulerViewModel(TurnSchedulerDTO turnScheduler) : base()
        {
            Map(turnScheduler);
        }

        private void Map(TurnSchedulerDTO turnScheduler)
        {
            var turns = new TurnViewModel[turnScheduler.Turns.Length];
            for (int i = 0; i < turnScheduler.Turns.Length; i++)
            {
                turns[i] = new TurnViewModel(turnScheduler.Turns[i]);
                if (turns[i].IsCurrent)
                    _currentTurn = turns[i];
            }
            Turns = turns;
        }

        public void NextTurn()
        {
            var index = Array.IndexOf(Turns, _currentTurn);
            if (index < Turns.Length)
            {
                _currentTurn.IsCurrent = false;
                _currentTurn = Turns[index + 1];
                _currentTurn.IsCurrent = true;
            }
            else
                throw new Exception("You can't go beyond the last turn.");
        }
    }
}
