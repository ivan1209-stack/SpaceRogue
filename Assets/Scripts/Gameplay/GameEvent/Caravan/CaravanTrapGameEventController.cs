using Gameplay.Player;
using Scriptables.GameEvent;

namespace Gameplay.GameEvent.Caravan
{
    public sealed class CaravanTrapGameEventController : CaravanGameEventController
    {
        public CaravanTrapGameEventController(GameEventConfig config, PlayerController playerController) : base(config, playerController)
        {
        }
    }
}