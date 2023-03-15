using Gameplay.Survival;
using Gameplay.Survival.DamageImmunityFrame;
using Gameplay.Survival.Health;
using Gameplay.Survival.Shield;
using Zenject;

namespace Gameplay.Installers
{
    public sealed class HealthInstaller : MonoInstaller
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