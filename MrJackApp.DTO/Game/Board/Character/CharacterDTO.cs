using System.Runtime.Serialization;

namespace MrJackApp.DTO.Game.Board.Character
{
    [DataContract]
    public sealed class CharacterDTO
    {
        [DataMember]
        public CharacterKind Kind { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int MinMove { get; set; }
        [DataMember]
        public int MaxMove { get; set; }
        [DataMember]
        public int X { get; set; }
        [DataMember]
        public int Y { get; set; }
    }
}
