using Zenject;

namespace Gameplay.Temp
{
    public class TempInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallPlayerSpawner();
        }

        private void InstallPlayerSpawner()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerSpawner>()
                .AsSingle();
        }
    }
}