using Gameplay.Mechanics.Timer;
using Zenject;

namespace Gameplay.Shooting.Factories
{
    public class ProjectileFactory : PlaceholderFactory<ProjectileSpawnParams, Projectile>
    {
        private readonly ProjectileViewFactory _projectileViewFactory;
        private readonly TimerFactory _timerFactory;

        public ProjectileFactory(ProjectileViewFactory projectileViewFactory, TimerFactory timerFactory)
        {
            _projectileViewFactory = projectileViewFactory;
            _timerFactory = timerFactory;
        }
        
        public override Projectile Create(ProjectileSpawnParams spawnParams)
        {
            var projectileView = _projectileViewFactory.Create(spawnParams);
            var projectile = new Projectile(spawnParams.Config, projectileView, _timerFactory);
            return projectile;
        }
    }
}