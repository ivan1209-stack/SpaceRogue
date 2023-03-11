using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scriptables.Space;

namespace SpaceObjects
{
    public class GravitationAuraFactory 
    {
        public GravitationAuraFactory(GravitationAuraConfig config)
        {

        }

        public GravitationAuraEffect CreateGravitationAuraEffect()
        {
            var gravitationAuraEffect = new GravitationAuraEffect();
            return gravitationAuraEffect;
        }

    }
}