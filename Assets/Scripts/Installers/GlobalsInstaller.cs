using Services;
using Services.SceneLoader;
using Zenject;

namespace Installers
{
    public class GlobalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneLoader();
            BindGameState();
            BindPlayerData();
            BindUpdater();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle()
                .NonLazy();
        }

        private void BindGameState()
        {
            Container
                .Bind<GameStateService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayerData()
        {
            Container
                .Bind<PlayerDataService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindUpdater()
        {
            Container
                .BindInterfacesAndSelfTo<Updater>()
                .AsSingle()
                .NonLazy();
        }
    }
}