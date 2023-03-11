using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scriptables.Space;

namespace SpaceObjects
{
    public class DamageOnTouchFactory
    {
        public DamageOnTouchFactory(DamageOnTouchEffectConfig config)
        {

        }

        public DamageOnTouchEffect CreateDamageOnTouchEffect()
        {
            var damageOnTouchEffect = new DamageOnTouchEffect();
            return damageOnTouchEffect;
        }
    }
}
