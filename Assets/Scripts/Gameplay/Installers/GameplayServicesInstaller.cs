using Abstracts;
using Gameplay.Background;
using Gameplay.Enemy;
using Gameplay.Enemy.Movement;
using Gameplay.Input;
using Gameplay.Mechanics.Meter;
using Gameplay.Mechanics.Timer;
using Gameplay.Movement;
using Gameplay.Services;
using Scriptables;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public sealed class GameplayServicesInstaller : MonoInstaller
    {
        [field: SerializeField] public GameBackgroundConfig GameBackgroundConfig { get; private set; }
        [field: SerializeField] public GameBackgroundView GameBackgroundView { get; private set; }

        [field: SerializeField] public PlayerInputConfig PlayerInputConfig { get; private set; }

        public override void InstallBindings()
        {
            InstallGameplayMechanics();
            InstallCurrentGameState();
            InstallBackground();
            InstallPlayerInput();
            InstallEnemyInput();
            InstallUnitMovement();
        }

        private void InstallGameplayMechanics()
        {
            Container
                .BindFactory<float, Timer, TimerFactory>()
                .AsSingle();

            Container
                .BindFactory<float, float, float, MeterWithCooldown, MeterWithCooldownFactory>()
                .AsSingle();
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
                .Bind<GameBackgroundConfig>()
                .FromInstance(GameBackgroundConfig)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<GameBackgroundView>()
                .FromInstance(GameBackgroundView)
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<GameBackground>()
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

        private void InstallEnemyInput()
        {
            Container
                .BindFactory<EnemyInput, EnemyInputFactory>()
                .AsSingle();
        }

        private void InstallUnitMovement()
        {
            Container
                .BindFactory<UnitMovementConfig, UnitMovementModel, UnitMovementModelFactory>()
                .AsSingle();

            Container
                .BindFactory<UnitView, IUnitMovementInput, UnitMovementModel, UnitMovement, UnitMovementFactory>()
                .AsSingle();
        }
    }
}