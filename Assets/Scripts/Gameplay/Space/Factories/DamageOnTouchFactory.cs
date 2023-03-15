using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using Zenject;

namespace Gameplay.Space.Factories
{
    public class DamageOnTouchFactory : PlaceholderFactory<DamageOnTouchConfig, DamageOnTouchEffect>
    {
        public DamageOnTouchFactory()
        {

        }

        public DamageOnTouchEffect CreateDamageOnTouchEffect(DamageOnTouchConfig config)
        {
            return base.Create(config);
        }
    }
}
