using System;
using Gameplay.Damage;
using Gameplay.Survival;
using UnityEngine;

namespace Abstracts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class UnitView : MonoBehaviour, IDamageableView
    {
        public abstract UnitType UnitType { get; }
        public event Action<DamageModel> DamageTaken = _ => { };

        public void TakeDamage(DamageModel damageModel)
        {
            DamageTaken(damageModel);
        }
    }
}