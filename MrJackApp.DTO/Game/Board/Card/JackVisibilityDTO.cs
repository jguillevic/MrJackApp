using System.Runtime.Serialization;

namespace MrJackApp.DTO.Game.Board.Card
{
    [DataContract]
    public sealed class JackVisibilityDTO
    {
        [DataMember]
        public bool IsVisibile { get; set; }
    }
}
