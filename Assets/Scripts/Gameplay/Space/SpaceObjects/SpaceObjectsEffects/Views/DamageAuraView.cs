using Gameplay.Damage;

namespace Gameplay.Space.SpaceObjects.SpaceObjectsEffects.Views
{
    public sealed class DamageAuraView : AreaEffectView, IDamagingView
    {
        public DamageModel DamageModel { get; private set; }

        public void Init(DamageModel damageModel)
        {
            DamageModel = damageModel;
        }
    }
}