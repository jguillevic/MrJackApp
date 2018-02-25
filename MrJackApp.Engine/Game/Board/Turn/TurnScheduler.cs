using MrJackApp.DTO.Game.Board.Turn;
using System;

namespace MrJackApp.Engine.Game.Board.Turn
{
    public sealed class TurnScheduler
    {   
        private int _minTurnIndex;
        private int _maxTurnIndex;
        private int _currentTurnIndex;

        public Turn[] Turns { get; set; } = new Turn[8];

        public int MinTurnValue
        {
            get
            {
                return Turns[_minTurnIndex].Value;
            }
        }

        public int MaxTurnValue
        {
            get
            {
                return Turns[_maxTurnIndex].Value;
            }
        }

        public int CurrentTurnValue
        {
            get
            {
                return Turns[_currentTurnIndex].Value;
            }
        }

        public bool IsLastTurn
        {
            get
            {
                return _currentTurnIndex >= _maxTurnIndex;
            }
        }

        public void Init()
        {
            Turns[0] = new Turn { Value = 1, IsCurrent = true };
            Turns[1] = new Turn { Value = 2 };
            Turns[2] = new Turn { Value = 3 };
            Turns[3] = new Turn { Value = 4 };
            Turns[4] = new Turn { Value = 5 };
            Turns[5] = new Turn { Value = 6 };
            Turns[6] = new Turn { Value = 7 };
            Turns[7] = new Turn { Value = 8 };

            _minTurnIndex = 0;
            _maxTurnIndex = 7;
            _currentTurnIndex = _minTurnIndex;
        }

        public void NextTurn()
        {
            if (IsLastTurn)
                throw new Exception("Can't do it when last turn !!!");

            _currentTurnIndex++;
        }

        public TurnSchedulerDTO GetDTO()
        {
            var turnScheduler = new TurnSchedulerDTO();

            turnScheduler.Turns = new TurnDTO[Turns.Length];

            for (int i = 0; i < Turns.Length; i++)
                turnScheduler.Turns[i] = Turns[i].GetDTO();

            return turnScheduler;
        }
    }
}
