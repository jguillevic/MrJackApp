using MrJackApp.DTO.Game.Player;

namespace MrJackApp.WCFService.Game.Player
{
    public sealed class Player
    {
        private PlayerKind _kind;
        private string _login;

        public Player(PlayerKind kind, string login)
        {
            _kind = kind;
            _login = login;
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

            player.Login = _login;

            return player;
        }
    }
}
