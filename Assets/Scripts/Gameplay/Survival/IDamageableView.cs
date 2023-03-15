using System;
using Gameplay.Damage;

namespace Gameplay.Survival
{
    public interface IDamageableView
    {
        public event Action<DamageModel> DamageTaken;
        public void TakeDamage(IDamagingView damageComponent);
    }
}