using Gameplay.Camera;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class CameraInstaller : MonoInstaller
    {
        [field: SerializeField] public CameraView GameCameraView { get; private set; }

        public override void InstallBindings()
        {
            InstallGameCamera();
        }

        private void InstallGameCamera()
        {
            Container
                .Bind<CameraView>()
                .FromInstance(GameCameraView)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<GameCamera>()
                .AsSingle()
                .NonLazy();
        }
    }
}