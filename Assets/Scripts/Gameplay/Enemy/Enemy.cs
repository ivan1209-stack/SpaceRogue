using System;
using Gameplay.Enemy.Movement;
using Gameplay.Survival;

namespace Gameplay.Enemy
{
    public sealed class Enemy : IDisposable
    {
        private readonly EnemyMovement _enemyMovement;
        private readonly EnemyTurning _enemyTurning;

        public EnemyView EnemyView { get; }
        public EntitySurvival Survival { get; }

        public Enemy(
            EnemyView enemyView, 
            EnemyMovement enemyMovement,
            EnemyTurning enemyTurning,
            EntitySurvival enemySurvival)
        {
            EnemyView = enemyView;
            _enemyMovement = enemyMovement;
            _enemyTurning = enemyTurning;
            Survival = enemySurvival;

            Survival.EntityHealth.HealthReachedZero += OnDeath;
        }

        public void Dispose()
        {
            Survival.EntityHealth.HealthReachedZero -= OnDeath;

            Survival.Dispose();
            _enemyMovement.Dispose();
            _enemyTurning.Dispose();

            UnityEngine.Object.Destroy(EnemyView.gameObject);
        }

        private void OnDeath()
        {
            Dispose();
        }
    }
}