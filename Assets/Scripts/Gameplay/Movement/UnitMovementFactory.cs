using Abstracts;
using Gameplay.Abstracts;
using Zenject;

namespace Gameplay.Movement
{
    public sealed class UnitMovementFactory : PlaceholderFactory<UnitView, IUnitMovementInput, UnitMovementModel, UnitMovement>
    {
    }
}