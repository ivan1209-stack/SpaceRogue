using System;
using UI.Game;
using Gameplay.Enemy;
using System.Collections.Generic;
using Gameplay.Camera;
using UnityEngine;
using Services;
using Gameplay.Survival;
using Utilities.Unity;

namespace UI.Services
{
    public sealed class EnemyStatusBarService : IDisposable
    {
        private const float HealthBarOffset = 5f;

        private readonly Updater _updater;
        private readonly Camera _mainCamera;
        private readonly EnemyHealthBarsView _barsView;
        private readonly float _scaleFactor;
        private readonly EnemyFactory _enemyFactory;
        private readonly EnemyStatusBarViewFactory _statusBarViewFactory;

        private readonly Dictionary<Enemy, HealthStatusBarView> _enemyStatusBarCollection = new();

        public EnemyStatusBarService(Updater updater, CameraView cameraView, EnemyHealthBarsView barsView, EnemyFactory enemyFactory, EnemyStatusBarViewFactory statusBarViewFactory)
        {
            _updater = updater;
            _mainCamera = cameraView.GetComponent<Camera>();
            _barsView = barsView;
            _scaleFactor = _barsView.GetComponentInParent<Canvas>().scaleFactor;
            _enemyFactory = enemyFactory;
            _statusBarViewFactory = statusBarViewFactory;

            _updater.SubscribeToUpdate(FollowEnemy);
            _enemyFactory.EnemyCreated += OnEnemyCreated;
        }

        public void Dispose()
        {
            _updater.UnsubscribeFromUpdate(FollowEnemy);
            _enemyFactory.EnemyCreated += OnEnemyCreated;

            foreach (var statusBar in _enemyStatusBarCollection)
            {
                var statusBarView = statusBar.Value;
                var survival = statusBar.Key.Survival;

                if (survival != null)
                {
                    survival.EntityHealth.HealthChanged -= 
                        () => UpdateHealthBar(statusBarView, survival);

                    if (statusBarView is HealthShieldStatusBarView shieldStatusBarView)
                    {
                        survival.EntityShield.ShieldChanged -= 
                            () => UpdateShieldBar(shieldStatusBarView, survival);
                    }
                }
            }

            _enemyStatusBarCollection.Clear();
        }

        private void OnEnemyCreated(Enemy enemy)
        {
            var statusBarView = _statusBarViewFactory.Create(enemy.Survival, _barsView);
            InitStatusBarView(statusBarView, enemy.Survival);
            _enemyStatusBarCollection.Add(enemy, statusBarView);
        }

        private void InitStatusBarView(HealthStatusBarView statusBarView, EntitySurvival entitySurvival)
        {
            statusBarView.HealthBar.Init(0f, entitySurvival.EntityHealth.MaximumHealth,
                entitySurvival.EntityHealth.CurrentHealth);

            entitySurvival.EntityHealth.HealthChanged += () => UpdateHealthBar(statusBarView, entitySurvival);

            if (statusBarView is HealthShieldStatusBarView shieldStatusBarView)
            {
                shieldStatusBarView.ShieldBar.Init(0f, entitySurvival.EntityShield.MaximumShield,
                entitySurvival.EntityShield.CurrentShield);

                entitySurvival.EntityShield.ShieldChanged += () => UpdateShieldBar(shieldStatusBarView, entitySurvival);
            }
        }

        private void UpdateHealthBar(HealthStatusBarView  statusBarView, EntitySurvival entitySurvival)
        {
            statusBarView.HealthBar.UpdateValue(entitySurvival.EntityHealth.CurrentHealth);
        }

        private void UpdateShieldBar(HealthShieldStatusBarView shieldStatusBarView, EntitySurvival entitySurvival)
        {
            shieldStatusBarView.ShieldBar.UpdateValue(entitySurvival.EntityShield.CurrentShield);
        }

        private void FollowEnemy()
        {
            foreach (var statusBar in _enemyStatusBarCollection)
            {
                var statusBarView = statusBar.Value;
                var view = statusBar.Key.EnemyView;

                if (!view.TryGetComponent(out Collider2D collider2D))
                {
                    return;
                }

                var bounds = collider2D.bounds;
                bounds.Expand(HealthBarOffset * 2);

                if (UnityHelper.IsObjectVisible(_mainCamera, bounds))
                {
                    statusBarView.Show();
                }
                else 
                {
                    statusBarView.Hide();
                }

                SetStatusBarPosition(view.transform.position, (RectTransform)statusBarView.transform);
            }
        }

        private void SetStatusBarPosition(Vector3 unitPosition, RectTransform statusBarRectTransform)
        {
            var position = _mainCamera.WorldToScreenPoint(unitPosition + Vector3.up * HealthBarOffset);
            position = new Vector3(position.x - Screen.width / 2, position.y - Screen.height / 2, 0);
            var finalPosition = position / _scaleFactor;

            statusBarRectTransform.anchoredPosition = finalPosition;
        }
    }
}