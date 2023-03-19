using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Space.SpaceObjects;

namespace Gameplay.Space
{
    public class Space : IDisposable
    {
        private readonly List<SpaceObject> _spaceObjects;

        public Space(List<SpaceObject> spaceObjects)
        {
            _spaceObjects = spaceObjects;
        }
        
        public void Dispose()
        {
            if (!_spaceObjects.Any()) return;
            
            _spaceObjects.ForEach(so => so.Dispose());
            _spaceObjects.Clear();
        }
    }
}