using Gameplay.Factories;
using Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [field: SerializeField] public PlayerView PlayerViewPrefab { get; private set; }
        
        public override void InstallBindings()
        {
            InstallPlayerView();
            //InstallPlayerMovement();
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
            
        }
    }
}