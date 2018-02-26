using MrJackApp.DTO.Game.Board.Character;
using System;

namespace MrJackApp.Engine.Game.Board.Character
{
    public sealed class SergentGoodley : Character
    {
        public override int Id { get; protected set; } = 5;
        public override string Name { get; protected set; } = "Sergent Goodley";
        public override int MinMove { get; protected set; } = 1;
        public override int MaxMove { get; protected set; } = 3;

        public SergentGoodley() : base() { }

        public override void ExecutePower()
        {
            throw new NotImplementedException();
        }

        protected override CharacterKind GetCharacterKind()
        {
            return CharacterKind.SergentGoodley;
        }
    }
}
