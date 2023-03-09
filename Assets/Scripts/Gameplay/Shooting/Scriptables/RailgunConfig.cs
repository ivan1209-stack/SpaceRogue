using UnityEngine;

namespace Gameplay.Shooting
{
    [CreateAssetMenu(fileName = nameof(RailgunConfig), menuName = "Configs/Weapons/" + nameof(RailgunConfig))]
    public sealed class RailgunConfig : SpecificWeaponConfig
    {
        [field: SerializeField] public ProjectileConfig RailgunProjectile { get; private set; }
    }
}