using Gameplay.Survival;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = nameof(AsteroidConfig), menuName = "Configs/Asteroids/" + nameof(AsteroidConfig))]
    public class AsteroidConfig : ScriptableObject
    {
        [field: SerializeField] public AsteroidView Prefab { get; private set; }
        [field: SerializeField] public AsteroidType Type { get; private set; }
        [field: SerializeField] public AsteroidSizeType SizeType { get; private set; }
        [field: SerializeField] public EntitySurvivalConfig SurvivalConfig { get; private set; }
        [field: SerializeField] public AsteroidMoveConfig MoveConfig { get; private set; }
        [field: SerializeField, Min(0.0f)] public float MaxSpawnRadius { get; private set; } = 100;
        [field: SerializeField, Min(0.0f)] public float AsteroidLifeTime { get; private set; } = 20;
        [field: SerializeField, Min(0.0f)] public float Damage { get; private set; } = 1;
    }
}