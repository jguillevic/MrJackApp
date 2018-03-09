using MrJackApp.DTO.Game.Board.Card;

namespace MrJackApp.Engine.Game.Board.Card
{
    public sealed class AlibiCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CharacterId { get; set; }

        public CardDTO GetDTO()
        {
            var card = new CardDTO();

            card.Name = Name;
            card.CharacterId = CharacterId;

            return card;
        }
    }
}
