using Zenject;
using UnityEngine;
using Scriptables.Space;

namespace SpaceObjects
{
    public class GravitationAuraFactory : PlaceholderFactory<GravitationAuraConfig, GravitationAuraEffect>
    {
        public GravitationAuraFactory()
        {

        }

        public GravitationAuraEffect CreateGravitationAuraEffect(GravitationAuraConfig config)
        {
            var gravitationAuraEffect = new GravitationAuraEffect();
            return gravitationAuraEffect;
        }

    }
}