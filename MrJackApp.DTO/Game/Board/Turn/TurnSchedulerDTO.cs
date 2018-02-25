using System.Runtime.Serialization;

namespace MrJackApp.DTO.Game.Board.Turn
{
    [DataContract]
    public sealed class TurnSchedulerDTO
    {
        [DataMember]
        public TurnDTO[] Turns { get; set; }
    }
}
