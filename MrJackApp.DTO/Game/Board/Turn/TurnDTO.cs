using System.Runtime.Serialization;

namespace MrJackApp.DTO.Game.Board.Turn
{
    [DataContract]
    public sealed class TurnDTO
    {
        [DataMember]
        public int Value { get; set; }
        [DataMember]
        public bool IsCurrent { get; set; }
    }
}
