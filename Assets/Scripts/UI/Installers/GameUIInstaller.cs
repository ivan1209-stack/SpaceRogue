using UI.Game;
using UnityEngine;
using Utilities.ResourceManagement;
using Zenject;

namespace UI.Installers
{
    public class GameUIInstaller : MonoInstaller
    {
        [field: SerializeField] public Transform uiPosition { get; private set; }
            
        private readonly ResourcePath _gameCanvasPath = new(Constants.Prefabs.Canvas.Game.GameCanvas);
        
        public override void InstallBindings()
        {
            BindGameUICanvas();
            BindGameUIFacade();
        }

        private void BindGameUICanvas()
        {
            GameCanvasView gameCanvasView = ResourceLoader.LoadPrefabAsChild<GameCanvasView>(_gameCanvasPath, uiPosition);

            Container
                .Bind<GameCanvasView>()
                .FromInstance(gameCanvasView)
                .AsSingle()
                .NonLazy();
        }

        private void BindGameUIFacade()
        {
            Container
                .BindInterfacesAndSelfTo<GameUIFacade>()
                .AsSingle()
                .NonLazy();
        }
    }
}