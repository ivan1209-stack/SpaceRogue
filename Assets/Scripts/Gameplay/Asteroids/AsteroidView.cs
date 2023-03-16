using Gameplay.Survival;
using System;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class AsteroidView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public Collider2D Collider { get; private set; }

        public event Action<IDamageableView> DamageDealt;
        public event Action ObjectDestroyed;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageableView victim)) DamageDealt.Invoke(victim);
            ObjectDestroyed?.Invoke();
        }
    }
}