using Abstracts;
using Gameplay.Abstracts;
using Zenject;

namespace Gameplay.Movement
{
    public sealed class UnitTurningMouseFactory : PlaceholderFactory<UnitView, IUnitTurningMouseInput, UnitMovementModel, UnitTurningMouse>
    {
    }
}