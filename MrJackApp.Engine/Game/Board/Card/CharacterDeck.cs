using MrJackApp.Engine.Helper;
using System.Collections.Generic;

namespace MrJackApp.Engine.Game.Board.Card
{
    public sealed class CharacterDeck
    {
        private List<CharacterCard> _cards;

        public CharacterDeck()
        {
            _cards = new List<CharacterCard>();
        }

        public void Init()
        {
            _cards.Add(new CharacterCard { Id = 0, Name = "Sherlock Holmes", CharacterId = 0 });
            _cards.Add(new CharacterCard { Id = 1, Name = "John H. Watson", CharacterId = 1 });
            _cards.Add(new CharacterCard { Id = 2, Name = "John Smith", CharacterId = 2 });
            _cards.Add(new CharacterCard { Id = 3, Name = "Inspecteur Lestrade", CharacterId = 3 });
            _cards.Add(new CharacterCard { Id = 4, Name = "Miss Stealthy", CharacterId = 4 });
            _cards.Add(new CharacterCard { Id = 5, Name = "Sergent Goodley", CharacterId = 5 });
            _cards.Add(new CharacterCard { Id = 6, Name = "Sir William Gull", CharacterId = 6 });
            _cards.Add(new CharacterCard { Id = 7, Name = "Jeremy Bert", CharacterId = 7 });
        }

        public void Shuffle()
        {
            ListHelper.Shuffle(_cards);
        }

        public List<CharacterCard> Draw(int count)
        {
            return ListHelper.Draw(_cards, count);
        }
    }
}
