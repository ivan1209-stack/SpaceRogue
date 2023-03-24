using Gameplay.Movement;
using Zenject;

namespace Gameplay.Enemy.Movement
{
    public sealed class EnemyTurningFactory : PlaceholderFactory<EnemyView, UnitMovementConfig, EnemyTurning>
    {
        private readonly EnemyInputFactory _enemyInputFactory;
        private readonly UnitMovementModelFactory _movementModelFactory;

        public EnemyTurningFactory(
            EnemyInputFactory enemyInputFactory, 
            UnitMovementModelFactory movementModelFactory)
        {
            _enemyInputFactory = enemyInputFactory;
            _movementModelFactory = movementModelFactory;
        }

        public override EnemyTurning Create(EnemyView enemyView, UnitMovementConfig movementConfig)
        {
            var input = _enemyInputFactory.Create();
            var model = _movementModelFactory.Create(movementConfig);
            return new(enemyView, input, model);
        }
    }
}