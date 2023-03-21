using Abstracts;
using Gameplay.Damage;
using Gameplay.Survival;
using UnityEngine;

namespace Gameplay.GameEvent.Caravan
{
    [RequireComponent(typeof(BoxCollider2D))]
    public sealed class CaravanView : UnitView, IDamagingView
    {
        public override UnitType UnitType => UnitType.Assistant;
        public bool IsLastDamageFromPlayer { get; private set; }
        public DamageModel DamageModel { get; private set; }

        public void Init(DamageModel damageModel)
        {
            DamageModel = damageModel;
        }

        public void DealDamage(IDamageableView damageable)
        {
            damageable.TakeDamage(DamageModel);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out IDamagingView damagingView))
            {
                if(damagingView.DamageModel.UnitType == UnitType.Player)
                {
                    IsLastDamageFromPlayer = true;
                }
            }
            else
            {
                IsLastDamageFromPlayer = false;
            }
        }
    }
}