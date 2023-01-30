using Abstracts;
using UI.Game;
using UnityEngine;
using Utilities.ResourceManagement;

namespace UI
{
    public sealed class MainUIController : BaseController
    {
        public MainCanvas MainCanvas { get; }
        
        private readonly ResourcePath _uiCameraPath = new(Constants.Prefabs.Canvas.UICamera);
        private readonly ResourcePath _mainCanvasPath = new(Constants.Prefabs.Canvas.MainCanvas);

        public MainUIController(Transform uiPosition)
        {
            var uiCamera = ResourceLoader.LoadPrefabAsChild<Camera>(_uiCameraPath, uiPosition);
            MainCanvas = ResourceLoader.LoadPrefabAsChild<MainCanvas>(_mainCanvasPath, uiPosition);
            var canvas = MainCanvas.GetComponent<Canvas>();
            canvas.worldCamera = uiCamera;
            
            AddGameObject(uiCamera.gameObject);
            AddGameObject(MainCanvas.gameObject);
        }
    }
}