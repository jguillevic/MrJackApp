using MrJackApp.Engine.Helper;
using System.Collections.Generic;

namespace MrJackApp.Engine.Game.Board.Card
{
    public sealed class AlibiDeck
    {
        public List<AlibiCard> _cards;

        public AlibiDeck()
        {
            _cards = new List<AlibiCard>();
        }

        public void Init()
        {
            _cards.Add(new AlibiCard { Id = 0, Name = "Sherlock Holmes", CharacterId = 0 });
            _cards.Add(new AlibiCard { Id = 1, Name = "John H. Watson", CharacterId = 1 });
            _cards.Add(new AlibiCard { Id = 2, Name = "John Smith", CharacterId = 2 });
            _cards.Add(new AlibiCard { Id = 3, Name = "Inspecteur Lestrade", CharacterId = 3 });
            _cards.Add(new AlibiCard { Id = 4, Name = "Miss Stealthy", CharacterId = 4 });
            _cards.Add(new AlibiCard { Id = 5, Name = "Sergent Goodley", CharacterId = 5 });
            _cards.Add(new AlibiCard { Id = 6, Name = "Sir William Gull", CharacterId = 6 });
            _cards.Add(new AlibiCard { Id = 7, Name = "Jeremy Bert", CharacterId = 7 });
        }

        public void Shuffle()
        {
            ListHelper.Shuffle(_cards);
        }

        public List<AlibiCard> Draw(int count)
        {
            return ListHelper.Draw(_cards, count);
        }
    }
}
