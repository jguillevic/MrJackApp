using MrJackApp.DTO.Game.Player;
using MrJackApp.ViewModel.Common;

namespace MrJackApp.ViewModel.Game.Board.Player
{
    public sealed class PlayerDisplayerViewModel : BindableBase
    {
        private PlayerKind _kind = PlayerKind.Undefined;
        public PlayerKind Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

        public bool IsJack
        {
            get
            {
                return Kind == PlayerKind.Jack;
            }
            
        }

        public PlayerDisplayerViewModel(PlayerDTO player) : base()
        {
            Map(player);
        }

        private void Map(PlayerDTO player)
        {
            switch (player.Kind)
            {
                case DTO.Game.Player.PlayerKind.Jack:
                    _kind = PlayerKind.Jack;
                    break;
                case DTO.Game.Player.PlayerKind.Inspector:
                    _kind = PlayerKind.Inspector;
                    break;
                default:
                    break;
            }
        }
    }
}
