using Gameplay.Health;
using Scriptables.Health;
using Zenject;

namespace Gameplay.Installers
{
    public class HealthInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindFactory<IHealthInfo, EntityHealth, EntityHealthFactory>()
                .AsSingle();
            
            Container
                .BindFactory<IShieldInfo, EntityShield, EntityShieldFactory>()
                .AsSingle();
            
            Container
                .BindFactory<IDamageImmunityFrameInfo, EntityDamageImmunityFrame, EntityDamageImmunityFrameFactory>()
                .AsSingle();
            
            Container
                .BindFactory<EntitySurvivalConfig, EntitySurvival, EntitySurvivalFactory>()
                .AsSingle();
        }
    }
}