using MrJackApp.DTO.Game.Board.Character;
using System.Collections.Generic;

namespace MrJackApp.Engine.Game.Board.Character
{
    public abstract class Character
    {
        public abstract int Id { get; protected set; }
        public abstract string Name { get; protected set; }
        public abstract int MinMove { get; protected set; }
        public abstract int MaxMove { get; protected set; }
        public int  X { get; set; }
        public int Y { get; set; }

        public abstract void ExecutePower();

        public void MoveTo(Tile.Tile tile)
        {
            X = tile.X;
            Y = tile.Y;
        }

        public bool CanMoveTo(Tile.Tile tile, Character[] characters)
        {
            foreach (var character in characters)
            {
                if (tile.X == character.X && tile.Y == character.Y)
                    return false;
            }

            return tile.CanGoOn;
        }

        public HashSet<Tile.Tile> GetReachableSquares(IEnumerable<Character> characters)
        {
            var reachableSquares = new HashSet<Tile.Tile>();

            //reachableSquares.Add(Square);
            //for (int i = 0; i < MaxMove; i++)
            //{
            //    //foreach (var square in reachableSquares.SelectMany(item => item.GetContiguousSquares()).ToList())
            //    //{
            //    //    if (square != null && square.CanGoOn)
            //    //        reachableSquares.Add(square);
            //    //}
            //}
            
            return reachableSquares;
        }

        public CharacterDTO GetDTO()
        {
            var character = new CharacterDTO();

            character.Id = Id;
            character.Name = Name;
            character.MinMove = MinMove;
            character.MaxMove = MaxMove;
            character.X = X;
            character.Y = Y;

            character.Kind = GetCharacterKind();

            return character;
        }

        protected abstract CharacterKind GetCharacterKind();
    }
}
