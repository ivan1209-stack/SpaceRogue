using Gameplay.Factories;
using Gameplay.Movement;
using Gameplay.Player;
using Gameplay.Player.Movement;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [field: SerializeField] public PlayerView PlayerViewPrefab { get; private set; }
        [field: SerializeField] public UnitMovementConfig PlayerMovementConfig { get; private set; }
        
        public override void InstallBindings()
        {
            InstallPlayerView();
            InstallPlayerMovement();
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
                .Bind<PlayerMovement>()
                .AsCached();
        }
    }
}