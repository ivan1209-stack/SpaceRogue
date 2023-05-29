using Gameplay.Enemy.Movement;
using Gameplay.Movement;
using Zenject;

namespace Gameplay.Enemy.Behaviour
{
    public sealed class EnemyBehaviourSwitcherFactory : PlaceholderFactory<EnemyView, EnemyInput, UnitMovementModel, EnemyBehaviourConfig, EnemyBehaviourSwitcher>
    {
    }
}