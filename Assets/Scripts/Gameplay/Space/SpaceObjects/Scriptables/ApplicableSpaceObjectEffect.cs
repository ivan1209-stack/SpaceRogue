using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using UnityEngine;

namespace Gameplay.Space.SpaceObjects.Scriptables
{
    [CreateAssetMenu(fileName = nameof(ApplicableSpaceObjectEffect), menuName = "Configs/Space/SpaceObjectEffects/" + nameof(ApplicableSpaceObjectEffect))]
    public class ApplicableSpaceObjectEffect : ScriptableObject
    {
        public SpaceObjectEffectType Type { get; private set; }
        public SpaceObjectEffectConfig Config { get; private set; }
    }
}
