using Gameplay.Damage;
using Gameplay.Pooling;
using UnityEngine;
using Zenject;

namespace Gameplay.Shooting.Factories
{
    public class ProjectileViewFactory : PlaceholderFactory<ProjectileSpawnParams, ProjectileView>
    {
        private readonly DiContainer _diContainer;
        private readonly Transform _projectilePoolTransform;

        public ProjectileViewFactory(DiContainer diContainer, ProjectilePool projectilePool)
        {
            _diContainer = diContainer;
            _projectilePoolTransform = projectilePool.transform;
        }

        public override ProjectileView Create(ProjectileSpawnParams spawnParams)
        {
            var (position, rotation, config, unitType) = spawnParams;
            var projectileView = _diContainer.InstantiatePrefabForComponent<ProjectileView>(config.Prefab, position, rotation, _projectilePoolTransform);
            projectileView.Init(new DamageModel(config.DamageAmount, unitType));
            projectileView.GetComponent<Rigidbody2D>().velocity = rotation.eulerAngles * config.Speed;
            Debug.Log(rotation.eulerAngles); //TODO fix initial impulse
            Debug.Log(projectileView.GetComponent<Rigidbody2D>().velocity);
            return projectileView;
        }
    }
}