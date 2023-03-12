using System;
using Abstracts;
using Gameplay.Shooting.Scriptables;
using Zenject;

namespace Gameplay.Shooting.Factories
{
    public sealed class WeaponFactory : PlaceholderFactory<WeaponConfig, UnitType, Weapon>
    {
        public override Weapon Create(WeaponConfig weaponConfig, UnitType unitType)
        {
            return weaponConfig.Type switch
            {
                WeaponType.None => new NullGun(),
                /*WeaponType.Blaster => expr,
                WeaponType.Shotgun => expr,
                WeaponType.Minigun => expr,
                WeaponType.Railgun => expr, TODO uncomment when realizing weapon types */
                _ => throw new ArgumentOutOfRangeException(nameof(weaponConfig.Type), weaponConfig.Type,
                    "A not-existent weapon type is provided")
            };
        }
    }
}