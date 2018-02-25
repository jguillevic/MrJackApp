using System.Runtime.Serialization;

namespace MrJackApp.DTO.Game.Board.Card
{
    [DataContract]
    public sealed class CardDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int CharacterId { get; set; }
    }
}
