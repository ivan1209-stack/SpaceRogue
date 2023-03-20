using System;
using System.Collections.Generic;
using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using Object = UnityEngine.Object;
using UnityEngine;

namespace Gameplay.Space.SpaceObjects
{
    public class DamageOnTouchEffect : SpaceObjectEffect
    {
        private readonly DamageOnTouchView _view;
        public DamageOnTouchEffect(DamageOnTouchView view, DamageOnTouchConfig config)
        {
            _view = view;
            //TO DO damageOnTouch
        }

        public override void Dispose()
        {
            Object.Destroy(_view.gameObject);
        }
    }
}
