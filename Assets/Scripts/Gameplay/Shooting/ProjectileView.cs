using System;
using Gameplay.Damage;
using Gameplay.Survival;
using UnityEngine;

namespace Gameplay.Shooting
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider))]
    public sealed class ProjectileView : MonoBehaviour, IDamagingView
    {
        public event Action CollidedObject = () => { };
        public DamageModel DamageModel { get; private set; }

        public void Init(DamageModel damageModel)
        {
            DamageModel = damageModel;
        }

        public void DealDamage(IDamageableView damageable)
        {
            damageable.TakeDamage(DamageModel);
        }
        
        public void OnTriggerEnter2D(Collider2D other)
        {   
            CollisionEnter(other.gameObject);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            CollisionEnter(collision.gameObject);
        }
        
        private void CollisionEnter(GameObject go)
        {
            var damageable = go.GetComponent<IDamageableView>();
            if (damageable is not null)
            {
                DealDamage(damageable);
            }

            CollidedObject.Invoke();
        }
    }
}