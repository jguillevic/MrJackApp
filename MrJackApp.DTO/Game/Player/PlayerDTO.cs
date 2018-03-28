using System.Runtime.Serialization;

namespace MrJackApp.DTO.Game.Player
{
    [DataContract]
    public sealed class PlayerDTO
    {
        [DataMember]
        public PlayerKind Kind { get; set; }
        [DataMember]
        public string Login { get; set; }
    }
}
