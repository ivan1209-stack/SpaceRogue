using Gameplay.Survival.Health;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = nameof(AsteroidConfig), menuName = "Configs/Asteroids/" + nameof(AsteroidConfig))]
    public class AsteroidConfig : ScriptableObject
    {
        [field: SerializeField] public AsteroidView AsteroidPrefab { get; private set; }
        [field: SerializeField] public AsteroidType AsteroidType { get; private set; }
        [field: SerializeField] public DamageConfig DamageConfig { get; private set; }
        [field: SerializeField] public HealthConfig HealthConfig { get; private set; }
        [field: SerializeField] public AsteroidMoveConfig AsteroidMoveConfig { get; private set; }
    }
}