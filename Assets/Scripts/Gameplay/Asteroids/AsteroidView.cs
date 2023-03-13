using Gameplay.Health;
using System;
using UnityEngine;

public class AsteroidView : MonoBehaviour
{
    public event Action<IDamageableView> DamageDealt;
    public event Action ObjectDestroyed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageableView victim)) DamageDealt.Invoke(victim);
        ObjectDestroyed?.Invoke();
    }
}
