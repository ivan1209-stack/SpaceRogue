using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using Object = UnityEngine.Object;

namespace Gameplay.Space.SpaceObjects
{
    public class DamageAuraEffect : SpaceObjectEffect
    {
        private readonly DamageAuraView _view;

        public DamageAuraEffect(DamageAuraView view, DamageAuraConfig config)
        {
            _view = view;
            //TODO damageAura
        }

        public override void Dispose()
        {
            Object.Destroy(_view.gameObject);
        }
    }
}