using System;
using System.Collections.Generic;
using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using Object = UnityEngine.Object;
using UnityEngine;

namespace Gameplay.Space.SpaceObjects
{
    public class GravitationAuraEffect : SpaceObjectEffect
    {
        private readonly GravitationAuraEffectView _view;
        private readonly PointEffector2D _pointEffector;
        private readonly GravitationAuraConfig _gravityConfig;

        public GravitationAuraEffect(GravitationAuraEffectView view, GravitationAuraConfig config)
        {
            _view = view;
            _pointEffector = view.GetComponent<PointEffector2D>();
            _pointEffector.forceMagnitude = -config.GravityForce;
            _pointEffector.forceVariation = -config.GravityVariation;
        }

        public override void Dispose()
        {
            Object.Destroy(_view);
        }
    }
}

