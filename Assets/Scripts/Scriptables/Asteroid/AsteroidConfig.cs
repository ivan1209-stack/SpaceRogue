using Gameplay.Survival;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = nameof(AsteroidConfig), menuName = "Configs/AsteroidObjects/" + nameof(AsteroidConfig))]
    public class AsteroidConfig : ScriptableObject
    {
        [field: SerializeField] public AsteroidView AsteroidPrefab { get; private set; }
        [field: SerializeField] public AsteroidType AsteroidType { get; private set; }
        [field: SerializeField] public AsteroidSizeType AsteroidSizeType { get; private set; }
        [field: SerializeField] public DamageConfig DamageConfig { get; private set; }
        [field: SerializeField] public EntitySurvivalConfig SurvivalConfig { get; private set; }
        [field: SerializeField] public AsteroidMoveConfig AsteroidMoveConfig { get; private set; }
        [field: SerializeField, Min(0)] public float MaxAsteroidSpawnOrbit { get; private set; }
        [field: SerializeField, Min(0)] public float AsteroidLifeTime { get; private set; }
    }
}