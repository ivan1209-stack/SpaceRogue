using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scriptables.Space;

namespace SpaceObjects
{
    public class PlanetSystemFactory
    {
        public PlanetSystemFactory(PlanetSystemConfig config)
        {

        }

        public PlanetSystemEffect CreatePlanetSystemEffect()
        {
            var planetSystemEffect = new PlanetSystemEffect();
            return planetSystemEffect;
        }
    }
}
