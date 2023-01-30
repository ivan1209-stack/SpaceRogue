using UI.Game;
using UnityEngine;
using Utilities.ResourceManagement;
using Zenject;

namespace Installers
{
    public class GlobalsInstaller : MonoInstaller
    {
        [SerializeField] private Transform uiPosition;
        
        private readonly ResourcePath _uiCameraPath = new(Constants.Prefabs.Canvas.UICamera);
        private readonly ResourcePath _mainCanvasPath = new(Constants.Prefabs.Canvas.MainCanvas);
        
        public override void InstallBindings()
        {
            BindMainCanvas();
        }

        private void BindMainCanvas()
        {
            var uiCamera = ResourceLoader.LoadPrefabAsChild<Camera>(_uiCameraPath, uiPosition);
            var mainCanvas = ResourceLoader.LoadPrefabAsChild<MainCanvas>(_mainCanvasPath, uiPosition);
            var canvas = mainCanvas.GetComponent<Canvas>();
            canvas.worldCamera = uiCamera;
            
            Container
                .Bind<MainCanvas>()
                .FromInstance(mainCanvas)
                .AsSingle()
                .NonLazy();
        }
    }
}