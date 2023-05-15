using Gameplay.Enemy;
using UnityEngine;
using System;

namespace Gameplay.Shooting
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class TurretView : MonoBehaviour
    {
        public event Action<EnemyView> TargetEntersTrigger = (_) => { };
        public event Action<EnemyView> TargetExitsTrigger = (_) => { };

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<EnemyView>(out EnemyView target))
            {
                TargetEntersTrigger(target);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<EnemyView>(out EnemyView target))
            {
                TargetExitsTrigger(target);
            }
        }

        internal void Rotate(Vector3 direction, float speed)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle + 270f, Vector3.forward), speed);//*Time.deltaTime
        }
    }
}