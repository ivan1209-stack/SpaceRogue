using Gameplay.Input;
using Gameplay.Movement;
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
            InstallPlayerInput();
            InstallUnitMovement();
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

        private void InstallUnitMovement()
        {
            Container
                .BindFactory<UnitMovementConfig, UnitMovementModel, UnitMovementModelFactory>()
                .AsSingle();
        }
    }
}