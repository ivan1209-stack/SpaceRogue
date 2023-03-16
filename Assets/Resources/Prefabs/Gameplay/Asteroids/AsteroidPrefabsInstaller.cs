using Scriptables;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Asteroids
{
    public class AsteroidPrefabsInstaller : MonoInstaller
    {
        [field: SerializeField] public List<WeightConfig<AsteroidConfig>> AsteroidPrefabs;

        public override void InstallBindings()
        {
            Container.Bind<List<WeightConfig<AsteroidConfig>>>(); //TODO finish injector
        }
    }
}