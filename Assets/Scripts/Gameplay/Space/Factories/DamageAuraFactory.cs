using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using UnityEngine;
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
            return base.Create(config);
        }
    }
}