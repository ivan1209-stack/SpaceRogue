using Abstracts;
using Gameplay.Damage;
using Gameplay.Survival;
using System;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    public class AsteroidView : UnitView, IDamagingView
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public CircleCollider2D Collider { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }

        public DamageModel DamageModel { get; private set; }

        public override UnitType UnitType => UnitType.None;

        public void InitDamageModel(DamageModel damageModel) => DamageModel = damageModel;

        public void DealDamage(IDamageableView damageable)
        {
            damageable.TakeDamage(DamageModel);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageableView victim)) DealDamage(victim);
            TakeDamage(DamageModel);
        }
    }
}