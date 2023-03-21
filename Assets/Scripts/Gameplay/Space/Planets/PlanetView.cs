using System;
using Gameplay.Damage;
using Gameplay.Space.SpaceObjects;
using Gameplay.Survival;
using UnityEngine;

namespace Gameplay.Space.Planets
{
    [RequireComponent(typeof(CircleCollider2D))]
    public sealed class PlanetView : MonoBehaviour, IDamagingView
    {
        public event Action CollidedSpaceObject = () => { };
        public event Action CollidedPlanet = () => { };

        public DamageModel DamageModel { get; private set; }

        public void Init(DamageModel damageModel)
        {
            DamageModel = damageModel;
        }

        public void DealDamage(IDamageableView damageable)
        {
            damageable.TakeDamage(DamageModel);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {   
            CollisionEnter(other.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
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
            
            if (go.TryGetComponent(out SpaceObjectView _))
            {
                CollidedSpaceObject();
                return;
            }
            
            if (go.TryGetComponent(out PlanetView _))
            {
                CollidedPlanet();
                return;
            }
        }
    }
}