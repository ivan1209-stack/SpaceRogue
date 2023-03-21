using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects.Views;
using Object = UnityEngine.Object;


namespace Gameplay.Space.SpaceObjects.SpaceObjectsEffects
{
    public sealed class DamageOnTouchEffect : SpaceObjectEffect
    {
        private readonly DamageOnTouchView _view;

        public DamageOnTouchEffect(DamageOnTouchView view, DamageOnTouchConfig config)
        {
            _view = view;
            //TODO damageOnTouch
        }

        public override void Dispose()
        {
            Object.Destroy(_view.gameObject);
        }
    }
}
