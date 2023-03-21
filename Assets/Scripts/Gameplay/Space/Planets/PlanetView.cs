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

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out SpaceObjectView _))
            {
                CollidedSpaceObject();
            }
            
            if (collision.gameObject.TryGetComponent(out PlanetView _))
            {
                CollidedPlanet();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out SpaceObjectView _))
            {
                CollidedSpaceObject();
            }
        }
    }
}