using Abstracts;
using Gameplay.Damage;
using Gameplay.Survival;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    public class AsteroidView : UnitView, IDamagingView
    {
        public DamageModel DamageModel { get; private set; }

        public override UnitType UnitType => UnitType.Asteroid;

        public void Init(float damage)
        {
            DamageModel = new(damage, UnitType);
        }

        public void DealDamage(IDamageableView damageable)
        {
            damageable.TakeDamage(DamageModel);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageableView victim)) DealDamage(victim); //TODO asteroid destroy on colision with non-IDamagebleView objects
        }
    }
}