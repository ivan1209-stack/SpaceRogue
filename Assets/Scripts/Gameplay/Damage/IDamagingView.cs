using Gameplay.Survival;

namespace Gameplay.Damage
{
    public interface IDamagingView
    {
        public DamageModel DamageModel { get; }
        public void DealDamage(IDamageableView damageable);
    }
}