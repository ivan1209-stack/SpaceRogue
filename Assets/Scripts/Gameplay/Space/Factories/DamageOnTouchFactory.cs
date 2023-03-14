using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using UnityEngine;
using Scriptables.Space;
using Zenject;

namespace SpaceObjects
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
