using System;
using Gameplay.Mechanics.Timer;
using Gameplay.Shooting.Scriptables;
using UnityEngine;

namespace Gameplay.Shooting
{
    public sealed class Projectile : IDisposable
    {
        private readonly ProjectileView _projectileView;
        private readonly Timer _lifeTime;
        
        public Projectile(ProjectileConfig config, ProjectileView projectileView, TimerFactory timerFactory) //TODO fix injection
        {
            _projectileView = projectileView;

            _lifeTime = timerFactory.Create(config.LifeTime);
            _lifeTime.OnExpire += Dispose;
            if (config.IsDestroyedOnHit) _projectileView.CollisionEnter += Dispose;
            
            _lifeTime.Start();
        }

        public void Dispose()
        {
            _lifeTime.OnExpire -= Dispose;
            _projectileView.CollisionEnter -= Dispose;
            UnityEngine.Object.Destroy(_projectileView);
        }
    }
}