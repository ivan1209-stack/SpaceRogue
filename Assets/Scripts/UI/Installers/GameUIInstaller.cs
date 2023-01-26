using UI.Game;
using Utilities.ResourceManagement;
using Zenject;

namespace UI.Installers
{
    public class GameUIInstaller : MonoInstaller
    {
        private readonly ResourcePath _gameCanvasPath = new(Constants.Prefabs.Canvas.Game.GameCanvas);
        
        public override void InstallBindings()
        {
            BindGameUICanvas();
            BindGameUIFacade();
        }

        private void BindGameUICanvas()
        {
            MainCanvas mainCanvas = Container.Resolve<MainCanvas>();
            GameCanvasView gameCanvasView = ResourceLoader.LoadPrefabAsChild<GameCanvasView>(_gameCanvasPath, mainCanvas.transform);

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