using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects.Views;
using UnityEngine;

namespace Gameplay.Space.SpaceObjects.Scriptables
{
    [CreateAssetMenu(fileName = nameof(DamageOnTouchConfig), menuName = "Configs/Space/SpaceObjectEffects/" + nameof(DamageOnTouchConfig))]
    public class DamageOnTouchConfig : SpaceObjectEffectConfig
    {
        [field: SerializeField, Header("AuraBody")] public DamageOnTouchEffectView Prefab { get; private set; }
        [field: SerializeField, Min(0.1f)] public float Damage { get; private set; }
        
        public DamageOnTouchConfig() => Type = SpaceObjectEffectType.DamageOnTouch;
    }
}