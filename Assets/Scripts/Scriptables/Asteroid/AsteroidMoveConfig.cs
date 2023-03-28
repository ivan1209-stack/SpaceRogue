using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = nameof(AsteroidMoveConfig), menuName = "Configs/Asteroids/" + nameof(AsteroidMoveConfig))]
    public class AsteroidMoveConfig : ScriptableObject
    {
        [field: SerializeField, Min(0.0f)] public float StartingSpeed { get; private set; }
        [field: SerializeField] public AsteroidMoveType MoveType { get; private set; }
    }
}
