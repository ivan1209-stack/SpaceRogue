using Abstracts;
using Gameplay.Abstracts;

namespace Gameplay.Player
{
    public sealed class PlayerView : UnitView
    {
        public override EntityType EntityType => EntityType.Player;
    }
}