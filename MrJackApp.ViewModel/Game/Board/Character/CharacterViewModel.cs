using MrJackApp.DTO.Game.Board.Character;
using MrJackApp.ViewModel.Common;

namespace MrJackApp.ViewModel.Game.Board.Character
{
    public abstract class CharacterViewModel : BindableBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinMove { get; set; }
        public int MaxMove { get; set; }
        private Coordinate _coordinate;
        public Coordinate Coordinate
        {
            get { return _coordinate; }
            private set { SetProperty(ref _coordinate, value); }
        }

        public CharacterViewModel(CharacterDTO character) : base()
        {
            Map(character);
        }

        protected void Map(CharacterDTO character)
        {
            Id = character.Id;
            Name = character.Name;
            MinMove = character.MinMove;
            MaxMove = character.MaxMove;
            Coordinate = new Coordinate(character.X, character.Y);
        }

        public void MoveTo(int x, int y)
        {
            Coordinate = new Coordinate(x, y);
        }
    }
}
