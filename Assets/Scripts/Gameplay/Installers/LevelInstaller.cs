using Gameplay.Services;
using Zenject;

namespace Gameplay.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallLevelProgressService();
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