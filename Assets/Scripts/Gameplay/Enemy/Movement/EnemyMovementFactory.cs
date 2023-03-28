using Gameplay.Movement;
using Zenject;

namespace Gameplay.Enemy.Movement
{
    public sealed class EnemyMovementFactory : PlaceholderFactory<EnemyView, EnemyInput, UnitMovementModel, EnemyMovement>
    {
    }
}