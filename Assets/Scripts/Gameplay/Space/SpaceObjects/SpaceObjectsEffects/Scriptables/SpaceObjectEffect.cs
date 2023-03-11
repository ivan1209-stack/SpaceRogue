using UnityEngine;
using SpaceObjects;

namespace Scriptables.Space
{
    [CreateAssetMenu(fileName = nameof(SpaceObjectEffect), menuName = "Configs/Space/" + nameof(SpaceObjectEffect))]
    public class SpaceObjectEffect : ScriptableObject
    {
        public SpaceObjectEffectType Type { get; private set; }
        public SpaceObjectEffectConfig Config { get; private set; }
    }
}
