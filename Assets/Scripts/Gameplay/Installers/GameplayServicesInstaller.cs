using Gameplay.Background;
using Gameplay.Input;
using Gameplay.Movement;
using Gameplay.Services;
using Scriptables;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public sealed class GameplayServicesInstaller : MonoInstaller
    {
        [field: SerializeField] public BackgroundConfig BackgroundConfig { get; private set; }
        [field: SerializeField] public BackgroundView BackgroundView { get; private set; }

        [field: SerializeField] public PlayerInputConfig PlayerInputConfig { get; private set; }

        public override void InstallBindings()
        {
            InstallCurrentGameState();
            InstallBackground();
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

        private void InstallBackground()
        {
            Container
                .Bind<BackgroundConfig>()
                .FromInstance(BackgroundConfig)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<BackgroundView>()
                .FromInstance(BackgroundView)
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<Background.Background>()
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