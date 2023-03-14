using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using Zenject;

namespace Gameplay.Space.Factories
{
    public class DamageAuraFactory : PlaceholderFactory<DamageAuraConfig, DamageAuraEffect>
    {
        public DamageAuraFactory()
        {

        }

        public DamageAuraEffect CreateDamageAuraEffect(DamageAuraConfig config)
        {
            return base.Create(config);
        }
    }
}