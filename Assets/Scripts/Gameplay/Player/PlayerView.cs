using Abstracts;

namespace Gameplay.Player
{
    public sealed class PlayerView : UnitView
    {
        public PlayerView()
        {
            UnitType = UnitType.Player;
        }
    }
}