using UnityEngine;
using Scriptables.Space;
using Zenject;

namespace SpaceObjects
{
    public class DamageAuraFactory : PlaceholderFactory<DamageAuraConfig, DamageAuraEffect>
    {
        public DamageAuraFactory()
        {

        }

        public DamageAuraEffect CreateDamageAuraEffect(DamageAuraConfig config)
        {
            var damageAuraEffect = new DamageAuraEffect();
            return damageAuraEffect;
        }
    }
}