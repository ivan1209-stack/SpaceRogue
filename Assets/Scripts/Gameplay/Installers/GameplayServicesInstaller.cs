using Gameplay.Input;
using Gameplay.Services;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class GameplayServicesInstaller : MonoInstaller
    {
        [field: SerializeField] public PlayerInputConfig PlayerInputConfig { get; set; }
        public override void InstallBindings()
        {
            InstallLevelProgressService();
            InstallPlayerInput();
        }

        private void InstallLevelProgressService()
        {
            Container
                .Bind<CurrentLevelProgress>()
                .AsSingle()
                .NonLazy();
        }

        private void InstallPlayerInput()
        {
            Container
                .Bind<PlayerInputConfig>()
                .FromInstance(PlayerInputConfig)
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<PlayerInput>()
                .AsSingle()
                .NonLazy();
        }
    }
}