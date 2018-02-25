using System;

namespace MrJackApp.Engine.Game.Board.Character
{
    public sealed class JeremyBert : Character
    {
        public override int Id { get; protected set; } = 7;
        public override string Name { get; protected set; } = "Jeremy Bert";
        public override int MinMove { get; protected set; } = 1;
        public override int MaxMove { get; protected set; } = 3;

        public JeremyBert() : base() { }

        public override void ExecutePower()
        {
            throw new NotImplementedException();
        }
    }
}
