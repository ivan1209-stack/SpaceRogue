using Gameplay.Damage;
using Gameplay.Pooling;
using Gameplay.Space.Planets;
using Gameplay.Space.SpaceObjects.Scriptables;
using UnityEngine;
using Utilities.Mathematics;
using Zenject;

namespace Gameplay.Space.Factories
{
    public class PlanetViewFactory : PlaceholderFactory<Vector2, PlanetConfig, PlanetView>
    {
        private readonly DiContainer _diContainer;
        private readonly Transform _spaceObjectsPoolTransform;

        public PlanetViewFactory(DiContainer diContainer, SpaceObjectsPool spaceObjectsPool)
        {
            _diContainer = diContainer;
            _spaceObjectsPoolTransform = spaceObjectsPool.transform;
        }
        
        public override PlanetView Create(Vector2 position, PlanetConfig config)
        {
            var view = _diContainer.InstantiatePrefabForComponent<PlanetView>(config.Prefab, position, Quaternion.identity, _spaceObjectsPoolTransform);
            var planetSize = RandomPicker.PickRandomBetweenTwoValues(config.MinSize, config.MaxSize);
            var planetDamage = RandomPicker.PickRandomBetweenTwoValues(config.MinDamage, config.MaxDamage);
            view.transform.localScale = new Vector3(planetSize, planetSize, 1);
            view.Init(new DamageModel(planetDamage));
            return view;
        }
    }
}