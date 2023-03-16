using UnityEngine;
using Zenject;
using Gameplay.Pooling;
using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects;
using Gameplay.Space.Factories;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;

namespace Gameplay.Installers
{
    public sealed class SpaceObjectsInstaller : MonoInstaller
    {
        [field: SerializeField] public SpaceObjectsPool SpaceObjectsPool { get; private set; }
        //[field: SerializeField] public SpaceObjectSpawnConfig SpaceObjectSpawnConfig { get; private set; }

        public override void InstallBindings()
        {
            InstallSpaceObjectViewFactory();
            InstallSpaceObjectEffectFactory();
            InstallSpaceObjectFactory();
        }

        private void InstallSpaceObjectViewFactory()
        {
            Container
                .Bind<SpaceObjectsPool>()
                .FromInstance(SpaceObjectsPool)
                .WhenInjectedInto<SpaceObjectViewFactory>();

            Container
                .BindFactory<Vector2, SpaceObjectConfig, SpaceObjectView, SpaceObjectViewFactory>()
                .AsSingle();
        }
        
        private void InstallSpaceObjectEffectFactory()
        {
            //TODO Remake
            Container
                .BindFactory<SpaceObjectEffectConfig, SpaceObjectEffect, SpaceObjectEffectFactory>().To<SpaceObjectEmptyEffect>()
                .AsSingle();
        }

        private void InstallSpaceObjectFactory()
        {
            Container
                .BindFactory<Vector2, SpaceObjectConfig, SpaceObject, SpaceObjectFactory>()
                .AsSingle();
        }
    }
}