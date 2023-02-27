using Gameplay.Camera;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public sealed class CameraInstaller : MonoInstaller
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
                .BindInterfacesAndSelfTo<GameCamera>()
                .AsSingle()
                .NonLazy();
        }
    }
}