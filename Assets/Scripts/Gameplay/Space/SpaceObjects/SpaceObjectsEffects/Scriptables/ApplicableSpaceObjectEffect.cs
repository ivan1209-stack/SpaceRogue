using UnityEngine;
using SpaceObjects;

namespace Scriptables.Space
{
    [CreateAssetMenu(fileName = nameof(ApplicableSpaceObjectEffect), menuName = "Configs/Space/SpaceObjectEffects/" + nameof(ApplicableSpaceObjectEffect))]
    public class ApplicableSpaceObjectEffect : ScriptableObject
    {
        public SpaceObjectEffectType Type { get; private set; }
        public SpaceObjectEffectConfig Config { get; private set; }
    }
}
