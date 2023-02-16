using UnityEngine;

namespace Gameplay.Input
{
    [CreateAssetMenu(fileName = nameof(PlayerInputConfig), menuName = "Configs/Input/" + nameof(PlayerInputConfig))]
    public class PlayerInputConfig : ScriptableObject
    {
        [field: SerializeField] public float HorizontalInputMultiplier { get; private set; } = 0.1f;
        [field: SerializeField] public float VerticalInputMultiplier { get; private set; } = 0.1f;
    }
}