using UnityEngine;

namespace Gameplay.Shooting
{
    [CreateAssetMenu(fileName = nameof(BlasterConfig), menuName = "Configs/Weapons/" + nameof(BlasterConfig))]
    public sealed class BlasterConfig : SpecificWeaponConfig
    {
        [field: SerializeField] public ProjectileConfig BlasterProjectile { get; private set; }
        [field: SerializeField, Range(0, 180)] public int SprayAngle { get; private set; } = 0;
    }
}