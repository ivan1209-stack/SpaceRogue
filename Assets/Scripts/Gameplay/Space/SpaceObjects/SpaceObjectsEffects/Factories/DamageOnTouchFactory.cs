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
            var damageOnTouchEffect = new DamageOnTouchEffect();
            return damageOnTouchEffect;
        }
    }
}
