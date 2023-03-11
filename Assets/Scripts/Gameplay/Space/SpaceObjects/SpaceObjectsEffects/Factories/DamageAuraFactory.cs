using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scriptables.Space;

namespace SpaceObjects
{
    public class DamageAuraFactory
    {
        public DamageAuraFactory(DamageAuraConfig config)
        {

        }

        public DamageAuraEffect CreateDamageAuraEffect()
        {
            var damageAuraEffect = new DamageAuraEffect();
            return damageAuraEffect;
        }
    }
}