using System;
using Gameplay.Enemy.Movement;
using Gameplay.Movement;
using Gameplay.Survival;

namespace Gameplay.Enemy
{
    public sealed class Enemy : IDisposable
    {
        private readonly UnitMovement _unitMovement;
        private readonly EnemyTurning _enemyTurning;

        public EnemyView EnemyView { get; }
        public EntitySurvival Survival { get; }

        public Enemy(
            EnemyView enemyView, 
            UnitMovement unitMovement,
            EnemyTurning enemyTurning,
            EntitySurvival enemySurvival)
        {
            EnemyView = enemyView;
            _unitMovement = unitMovement;
            _enemyTurning = enemyTurning;
            Survival = enemySurvival;

            Survival.EntityHealth.HealthReachedZero += OnDeath;
        }

        public void Dispose()
        {
            Survival.EntityHealth.HealthReachedZero -= OnDeath;

            Survival.Dispose();
            _unitMovement.Dispose();
            _enemyTurning.Dispose();

            UnityEngine.Object.Destroy(EnemyView.gameObject);
        }

        private void OnDeath()
        {
            Dispose();
        }
    }
}