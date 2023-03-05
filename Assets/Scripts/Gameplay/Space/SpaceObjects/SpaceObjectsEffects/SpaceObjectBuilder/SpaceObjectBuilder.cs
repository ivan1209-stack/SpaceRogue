using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceObjects
{
    public class SpaceObjectBuilder : ISpaceObjectBuilder
    {
        //private SpaceObject _spaceObject;

        //private readonly IEnumerable<>

        public ISpaceObjectBuilder BuildPlanetSystem()
        {

            return this;
        }

        public ISpaceObjectBuilder BuildGravityAura()
        {
            return this;
        }

        public ISpaceObjectBuilder BuildDamageAura()
        {

            return this;
        }
    }
}
