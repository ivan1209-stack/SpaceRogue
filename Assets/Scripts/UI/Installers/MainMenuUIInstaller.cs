using UI.Game;
using UI.MainMenu;
using UnityEngine;
using Zenject;

namespace UI.Installers
{
    public class MainMenuUIInstaller : MonoInstaller
    {
        [field: SerializeField] public MainMenuCanvasView MainMenuCanvas { get; private set; }
        
        public override void InstallBindings()
        {
            BindMainMenuCanvas();
            BindMainMenu();
        }

        private void BindMainMenuCanvas()
        {
            Container
                .Bind<MainMenuCanvasView>()
                .FromInstance(MainMenuCanvas)
                .AsSingle()
                .NonLazy();
        }

        private void BindMainMenu()
        {
            Container
                .BindInterfacesAndSelfTo<MainMenuUIFacade>()
                .AsSingle()
                .NonLazy();
        }
    }
}