using Gameplay.Input;
using Gameplay.Movement;
using Gameplay.Services;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public sealed class GameplayServicesInstaller : MonoInstaller
    {
        [field: SerializeField] public PlayerInputConfig PlayerInputConfig { get; private set; }

        public override void InstallBindings()
        {
            InstallCurrentGameState();
            InstallPlayerInput();
            InstallUnitMovement();
        }

        private void InstallCurrentGameState()
        {
            Container
                .Bind<CurrentGameState>()
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

        private void InstallUnitMovement()
        {
            Container
                .BindFactory<UnitMovementConfig, UnitMovementModel, UnitMovementModelFactory>()
                .AsSingle();
        }
    }
}