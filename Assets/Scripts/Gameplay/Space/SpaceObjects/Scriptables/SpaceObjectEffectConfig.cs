using UnityEngine;

namespace Gameplay.Space.SpaceObjects.Scriptables
{
    public abstract class SpaceObjectEffectConfig : ScriptableObject
    {
        [field: HideInInspector] public SpaceObjectEffectType Type { get; protected set; } = SpaceObjectEffectType.None;
    }
}