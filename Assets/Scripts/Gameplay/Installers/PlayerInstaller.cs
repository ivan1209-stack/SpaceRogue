using Gameplay.Factories;
using Gameplay.Movement;
using Gameplay.Player;
using Gameplay.Player.Movement;
using Scriptables;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [field: SerializeField] public PlayerView PlayerViewPrefab { get; private set; }
        [field: SerializeField] public PlayerConfig PlayerConfig { get; private set; }
        
        public override void InstallBindings()
        {
            InstallPlayerView();
            InstallPlayerMovement();
            InstallPlayer();
        }

        private void InstallPlayerView()
        {
            Container
                .Bind<PlayerView>()
                .FromInstance(PlayerViewPrefab)
                .WhenInjectedInto<PlayerViewFactory>();

            Container
                .BindFactory<Vector2, PlayerView, PlayerViewFactory>()
                .AsSingle();
        }

        private void InstallPlayerMovement()
        {
            Container
                .Bind<UnitMovementConfig>()
                .FromInstance(PlayerConfig.UnitMovement)
                .WhenInjectedInto<PlayerMovement>();
            
            Container
                .Bind<UnitMovementConfig>()
                .FromInstance(PlayerConfig.UnitMovement)
                .WhenInjectedInto<PlayerTurning>();
            
            Container
                .BindFactory<PlayerView, PlayerMovement, PlayerMovementFactory>()
                .AsSingle();
            
            Container
                .BindFactory<PlayerView, PlayerTurning, PlayerTurningFactory>()
                .AsSingle();
            
            Container
                .Bind<PlayerMovement>()
                .AsCached();

            Container
                .Bind<PlayerTurning>()
                .AsCached();
        }

        private void InstallPlayer()
        {
            Container
                .BindFactory<Vector2, Player.Player, PlayerFactory>()
                .AsSingle();
        }
    }
}