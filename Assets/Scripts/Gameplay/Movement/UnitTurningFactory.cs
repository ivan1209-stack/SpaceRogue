using Abstracts;
using Zenject;

namespace Gameplay.Movement
{
    public sealed class UnitTurningFactory : PlaceholderFactory<UnitView, IUnitTurningInput, UnitMovementModel, UnitTurning>
    {
    }
}