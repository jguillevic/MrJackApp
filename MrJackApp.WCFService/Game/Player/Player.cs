using MrJackApp.DTO.Game.Player;

namespace MrJackApp.WCFService.Game.Player
{
    public sealed class Player
    {
        private PlayerKind _kind;

        public Player(PlayerKind kind)
        {
            _kind = kind;
        }

        public PlayerDTO GetDTO()
        {
            var player = new PlayerDTO();

            switch (_kind)
            {
                case PlayerKind.Jack:
                    player.Kind = DTO.Game.Player.PlayerKind.Jack;
                    break;
                case PlayerKind.Inspector:
                    player.Kind = DTO.Game.Player.PlayerKind.Inspector;
                    break;
                default:
                    break;
            }

            return player;
        }
    }
}
