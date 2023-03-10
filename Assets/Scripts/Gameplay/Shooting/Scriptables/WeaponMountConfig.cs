using UnityEngine;

namespace Gameplay.Shooting.Scriptables
{
    [CreateAssetMenu(fileName = nameof(WeaponMountConfig), menuName = "Configs/Weapons/" + nameof(WeaponMountConfig))]
    public class WeaponMountConfig : ScriptableObject
    {
        [field: SerializeField] public WeaponMountType WeaponMountType { get; private set; } = WeaponMountType.None;
        [field: SerializeField] public WeaponConfig MountedWeapon { get; private set; }
    }
}