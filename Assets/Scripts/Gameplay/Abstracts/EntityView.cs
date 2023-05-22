using System;
using Gameplay.Damage;
using Gameplay.Survival;
using UnityEngine;

namespace Gameplay.Abstracts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class EntityView : MonoBehaviour, IDamageableView
    {
        public abstract EntityType EntityType { get; }
        public event Action<DamageModel> DamageTaken = _ => { };
        public event Action EntityDestroyed = () => { };

        public void TakeDamage(DamageModel damageModel)
        {
            DamageTaken(damageModel);
        }

        public void OnDestroy()
        {
            EntityDestroyed();
        }

        public int CompareTo(object obj)
        {
            return EntityType.CompareTo(obj);
        }
    }
}