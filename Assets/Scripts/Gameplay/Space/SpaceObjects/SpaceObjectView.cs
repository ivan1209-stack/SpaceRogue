using UnityEngine;

namespace Gameplay.Space.SpaceObjects
{
    public sealed class SpaceObjectView : MonoBehaviour
    {
        [field: SerializeField] public SpriteRenderer MinimapIconSpriteRenderer { get; private set; }
    }
}
