using Gameplay.Enemy.Movement;
using Gameplay.Movement;
using Gameplay.Services;
using Services;
using System;
using UnityEngine;
using Utilities.Unity;

namespace Gameplay.Enemy.Behaviour
{
    public abstract class EnemyBehaviour : IDisposable
    {
        private readonly Updater _updater;
        private readonly PlayerLocator _playerLocator;
        private readonly EnemiesAlarm _enemiesAlarm;

        protected readonly EnemyView View;
        protected readonly EnemyInput Input;
        protected readonly UnitMovementModel Model;
        protected readonly EnemyBehaviourConfig Config;

        protected Vector3 MovementDirection;

        public EnemyState CurrentState { get; private set; }
        public Transform TargetTransform { get; private set; }

        public event Action<EnemyState> EnemyStateChanged = _ => { };

        protected EnemyBehaviour(
            Updater updater,
            PlayerLocator playerLocator,
            EnemiesAlarm enemiesAlarm,
            EnemyState state,
            Action<EnemyState> enemyStateChanged,
            EnemyView view,
            EnemyInput input,
            UnitMovementModel model,
            EnemyBehaviourConfig config,
            Transform targetTransform = null)
        {
            _updater = updater;
            _playerLocator = playerLocator;
            _enemiesAlarm = enemiesAlarm;
            View = view;
            Input = input;
            Model = model;
            CurrentState = state;
            EnemyStateChanged = enemyStateChanged;
            Config = config;

            if (targetTransform == null)
            {
                ActiveTargetSearch();
            }
            else
            {
                TargetDetected(targetTransform);
            }

            _updater.SubscribeToUpdate(Update);
        }

        public void Dispose()
        {
            OnDispose();

            _playerLocator.PlayerTransform -= CheckLocator;
            _enemiesAlarm.Alarm -= OnAlarm;

            _updater.UnsubscribeFromUpdate(ContinuouslyCheckDistance);
            _updater.UnsubscribeFromUpdate(Update);
        }

        public virtual void SetMovementDirection(Vector3 direction) { }

        protected abstract void OnUpdate();

        protected virtual void OnDispose() { }

        protected virtual void OnTargetInZone()
        {
            Debug.Log("OnTargetInZone");
            ChangeState(EnemyState.InCombat);
        }
        
        protected virtual void OnAcceptAlarm()
        {
            Debug.Log("OnAcceptAlarm");
            ChangeState(EnemyState.InCombat);
        }
        
        protected virtual void OnLosingTarget()
        {
            Debug.Log("OnLosingTarget");
            ChangeState(EnemyState.PassiveRoaming);
        }

        protected void ChangeState(EnemyState newState)
        {
            if (newState != CurrentState)
            {
                CurrentState = newState;
                EnemyStateChanged.Invoke(CurrentState);
            }
        }

        private void Update()
        {
            if (View == null)
            {
                return;
            }

            OnUpdate();
        }

        private void ActiveTargetSearch()
        {
            _updater.UnsubscribeFromUpdate(ContinuouslyCheckDistance);
            _playerLocator.PlayerTransform += CheckLocator;
            _enemiesAlarm.Alarm += OnAlarm;
        }

        private void TargetDetected(Transform targetTransform)
        {
            TargetTransform = targetTransform;
            _playerLocator.PlayerTransform -= CheckLocator;
            _enemiesAlarm.Alarm -= OnAlarm;
            _updater.SubscribeToUpdate(ContinuouslyCheckDistance);
        }

        private void ContinuouslyCheckDistance()
        {
            if (TargetTransform == null)
            {
                ActiveTargetSearch();
                return;
            }

            if (View == null)
            {
                return;
            }

            var inDetectionRadius = UnityHelper.InDetectionRadius(
                View.transform.position,
                TargetTransform.position,
                Config.PlayerDetectionRadius);

            if (inDetectionRadius)
            {
                OnTargetInZone();
            }
            else
            {
                OnLosingTarget();
            }
        }

        private void CheckLocator(Transform targetTransform)
        {
            if (TargetTransform == targetTransform)
            {
                return;
            }

            var inDetectionRadius = UnityHelper.InDetectionRadius(
                View.transform.position,
                targetTransform.position,
                Config.PlayerDetectionRadius);

            if (inDetectionRadius)
            {
                Debug.Log("ALARM");
                _enemiesAlarm.AlarmSignal(View, targetTransform, Config.CallToArmsRadius);
                TargetDetected(targetTransform);
            }
        }

        private void OnAlarm(EnemyView signalingEnemy, Transform targetTransform, float alarmRadius)
        {
            if (View == signalingEnemy)
            {
                return;
            }

            if(TargetTransform == targetTransform)
            {
                return;
            }

            var inDetectionRadius = UnityHelper.InDetectionRadius(
                View.transform.position,
                signalingEnemy.transform.position,
                alarmRadius);

            if (inDetectionRadius)
            {
                Debug.Log("ACCEPT_ALARM");
                TargetDetected(targetTransform);
                OnAcceptAlarm();
            }
        }
    }
}