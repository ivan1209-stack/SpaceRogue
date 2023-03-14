using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using Zenject;

namespace Gameplay.Space.Factories
{
    public class DamageOnTouchFactory : PlaceholderFactory<DamageOnTouchEffectConfig, DamageOnTouchEffect>
    {
        public DamageOnTouchFactory()
        {

        }

        public DamageOnTouchEffect CreateDamageOnTouchEffect(DamageOnTouchEffectConfig config)
        {
            return base.Create(config);
        }
    }
}
