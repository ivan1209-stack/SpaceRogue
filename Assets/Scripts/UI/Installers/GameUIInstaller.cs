using UI.Game;
using UnityEngine;
using Zenject;

namespace UI.Installers
{
    public sealed class GameUIInstaller : MonoInstaller
    {
        [field: Header("GameUICanvas")]
        [field: SerializeField] public MainCanvas MainCanvas { get; private set; }
        [field: SerializeField] public GameCanvasView GameCanvasView{ get; private set; }

        [field: Header("Permanent UI")]
        [field: SerializeField] public PlayerInfoView PlayerInfoView{ get; private set; }
        [field: SerializeField] public LevelInfoView LevelInfoView{ get; private set; }
        [field: SerializeField] public MinimapView MinimapView { get; private set; }

        [field: Header("For instantiate other UI")]
        [field: SerializeField] public EnemyHealthBarsView EnemyHealthBarsView { get; private set; }
        [field: SerializeField] public GameEventIndicatorsView GameEventIndicatorsView { get; private set; }

        public override void InstallBindings()
        {
            BindGameUICanvas();
            BindPlayerInfo();
            BindLevelInfo();
            BindMinimap();
            //TODO
            //BindOtherUI();
        }

        private void BindGameUICanvas()
        {
            Container
                .Bind<MainCanvas>()
                .FromInstance(MainCanvas)
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<GameCanvasView>()
                .FromInstance(GameCanvasView)
                .AsSingle()
                .NonLazy();
        }
        
        private void BindPlayerInfo()
        {
            Container
                .Bind<PlayerInfoView>()
                .FromInstance(PlayerInfoView)
                .AsSingle()
                .NonLazy();
        }
        
        private void BindLevelInfo()
        {
            Container
                .Bind<LevelInfoView>()
                .FromInstance(LevelInfoView)
                .AsSingle()
                .NonLazy();
        }
        
        private void BindMinimap()
        {
            Container
                .Bind<MinimapView>()
                .FromInstance(MinimapView)
                .AsSingle()
                .NonLazy();
        }
        
        private void BindOtherUI()
        {
            Container
                .Bind<EnemyHealthBarsView>()
                .FromInstance(EnemyHealthBarsView)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<GameEventIndicatorsView>()
                .FromInstance(GameEventIndicatorsView)
                .AsSingle()
                .NonLazy();
        }
    }
}