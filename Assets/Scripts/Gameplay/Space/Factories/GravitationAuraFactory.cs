using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using Zenject;
using UnityEngine;

namespace SpaceObjects
{
    public class GravitationAuraFactory : PlaceholderFactory<GravitationAuraConfig, GravitationAuraEffect>
    {
        public GravitationAuraFactory()
        {

        }

        public GravitationAuraEffect CreateGravitationAuraEffect(GravitationAuraConfig config)
        {
            return base.Create(config);
        }

    }
}