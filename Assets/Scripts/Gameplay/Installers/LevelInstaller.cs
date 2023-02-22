using Gameplay.Factories;
using Gameplay.Services;
using Zenject;

namespace Gameplay.Installers
{
    public sealed class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallLevel();
            InstallLevelProgressService();
        }

        private void InstallLevel()
        {
            Container
                .BindFactory<int, Level, LevelFactory>()
                .AsSingle();
        }

        private void InstallLevelProgressService()
        {
            Container
                .Bind<CurrentLevelProgress>()
                .AsSingle()
                .NonLazy();
        }
    }
}