using Gameplay.Damage;
using Gameplay.Survival;

namespace Gameplay.Space.SpaceObjects.SpaceObjectsEffects.Views
{
    public sealed class DamageOnTouchEffectView : AreaEffectView, IDamagingView
    {
        public DamageModel DamageModel { get; private set; }

        public void Init(DamageModel damageModel)
        {
            DamageModel = damageModel;
        }

        public void DealDamage(IDamageableView damageable)
        {
            damageable.TakeDamage(DamageModel);
        }
    }
}