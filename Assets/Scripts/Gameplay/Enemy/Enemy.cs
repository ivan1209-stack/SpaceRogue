using System;
using Gameplay.Enemy.Behaviour;
using Gameplay.Movement;
using Gameplay.Survival;
using UnityEngine;

namespace Gameplay.Enemy
{
    public sealed class Enemy : IDisposable
    {
        private readonly UnitMovement _unitMovement;
        private readonly UnitTurning _unitTurning;
        private readonly EnemyBehaviourSwitcher _behaviourSwitcher;

        public event Action<Enemy> EnemyDestroyed = _ => { };

        public int GroupNumber { get; }
        public EnemyView EnemyView { get; }
        public EntitySurvival Survival { get; }

        public Enemy(
            int groupNumber,
            EnemyView enemyView, 
            UnitMovement unitMovement,
            UnitTurning unitTurning,
            EnemyBehaviourSwitcher behaviourSwitcher,
            EntitySurvival enemySurvival)
        {
            GroupNumber = groupNumber;
            EnemyView = enemyView;
            _unitMovement = unitMovement;
            _unitTurning = unitTurning;
            _behaviourSwitcher = behaviourSwitcher;
            Survival = enemySurvival;

            Survival.EntityHealth.HealthReachedZero += OnDeath;
        }

        public void Dispose()
        {
            Survival.EntityHealth.HealthReachedZero -= OnDeath;

            EnemyDestroyed.Invoke(this);

            Survival.Dispose();
            _unitMovement.Dispose();
            _unitTurning.Dispose();
            _behaviourSwitcher.Dispose();

            UnityEngine.Object.Destroy(EnemyView.gameObject);
        }

        public void SetMovementDirection(Vector3 direction)
        {
            _behaviourSwitcher.CurrentBehaviour.SetMovementDirection(direction);
        }

        private void OnDeath()
        {
            Dispose();
        }
    }
}