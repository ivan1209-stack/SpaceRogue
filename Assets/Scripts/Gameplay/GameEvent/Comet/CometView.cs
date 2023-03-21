using System;
using Gameplay.Damage;
using Gameplay.Space.Planets;
using Gameplay.Space.SpaceObjects;
using Gameplay.Survival;
using UnityEngine;

namespace Gameplay.GameEvent.Comet
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D), typeof(TrailRenderer))]
    public sealed class CometView : MonoBehaviour, IDamagingView
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
            if (collision.gameObject.TryGetComponent(out PlanetView _))
            {
                CollidedPlanet();
                return;
            }
            
            if (collision.gameObject.TryGetComponent(out SpaceObjectView _))
            {
                CollidedSpaceObject();
            }
        }
    }
}