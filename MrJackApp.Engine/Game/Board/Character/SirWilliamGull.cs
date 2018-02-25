﻿using System;

namespace MrJackApp.Engine.Game.Board.Character
{
    public sealed class SirWilliamGull : Character
    {
        public override int Id { get; protected set; } = 6;
        public override string Name { get; protected set; } = "Sir William Gull";
        public override int MinMove { get; protected set; } = 1;
        public override int MaxMove { get; protected set; } = 3;

        public SirWilliamGull() : base() { }

        public override void ExecutePower()
        {
            throw new NotImplementedException();
        }
    }
}
