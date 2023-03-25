using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects.Views;
using Object = UnityEngine.Object;


namespace Gameplay.Space.SpaceObjects.SpaceObjectsEffects
{
    public sealed class DamageOnTouchEffect : SpaceObjectEffect
    {
        private readonly DamageOnTouchEffectView _effectView;

        public DamageOnTouchEffect(DamageOnTouchEffectView effectView, DamageOnTouchConfig config)
        {
            _effectView = effectView;
            _effectView.CollidedSpaceObjectEffect += OnSpaceObjectCollision;
            //TODO damageOnTouch
        }

        public override void Dispose()
        {
            _effectView.CollidedSpaceObjectEffect -= OnSpaceObjectCollision;
            Object.Destroy(_effectView.gameObject);
        }

        private void OnSpaceObjectCollision()
        {
            //TODO 
            Dispose();
        }
    }
}
