using System;

namespace MrJackApp.Engine.Game.Board.Character
{
    public sealed class MissStealthy : Character
    {
        public override int Id { get; protected set; } = 4;
        public override string Name { get; protected set; } = "Miss Stealthy";
        public override int MinMove { get; protected set; } = 1;
        public override int MaxMove { get; protected set; } = 4;

        public MissStealthy() : base() { }

        public override void ExecutePower()
        {
            throw new NotImplementedException();
        }
    }
}
