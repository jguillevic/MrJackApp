﻿using System;

namespace MrJackApp.Engine.Game.Board.Character
{
    public sealed class JohnHWatson : Character
    {
        public override int Id { get; protected set; } = 1;
        public override string Name { get; protected set; } = "John H.Watson";
        public override int MinMove { get; protected set; } = 1;
        public override int MaxMove { get; protected set; } = 3;

        public JohnHWatson() : base() { }

        public override void ExecutePower()
        {
            throw new NotImplementedException();
        }
    }
}
