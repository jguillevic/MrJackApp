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
        public CoordinateViewModel Coordinate { get; private set; }

        public CharacterViewModel(CharacterDTO character) : base()
        {
            Map(character);
        }

        protected virtual void Map(CharacterDTO character)
        {
            Id = character.Id;
            Name = character.Name;
            MinMove = character.MinMove;
            MaxMove = character.MaxMove;
            Coordinate = new CoordinateViewModel(character.X, character.Y);
        }

        public void MoveTo(int x, int y)
        {
            Coordinate.X = x;
            Coordinate.Y = y;
            RaisePropertyChanged("Coordinate");
        }
    }
}
