using System;
using Abstracts;
using Gameplay.Shooting.Scriptables;
using Zenject;

namespace Gameplay.Shooting.Factories
{
    public class MountedWeaponFactory : IFactory<MountedWeaponConfig, UnitView, MountedWeapon>
    {
        private readonly IFactory<WeaponConfig, UnitType, Weapon> _weaponFactory;
        private readonly GunPointViewFactory _gunPointViewFactory;
        private readonly TurretViewFactory _turretViewFactory;

        public MountedWeaponFactory(IFactory<WeaponConfig, UnitType, Weapon> weaponFactory, GunPointViewFactory gunPointViewFactory, TurretViewFactory turretViewFactory)
        {
            _weaponFactory = weaponFactory;
            _gunPointViewFactory = gunPointViewFactory;
            _turretViewFactory = turretViewFactory;
        }

        public MountedWeapon Create(MountedWeaponConfig config, UnitView unitView)
        {
            return config.WeaponMountType switch
            {
                WeaponMountType.None => new UnmountedWeapon(CreateWeapon(config, unitView), unitView),
                WeaponMountType.Frontal => new FrontalMountedWeapon(CreateWeapon(config, unitView), unitView, _gunPointViewFactory),
                WeaponMountType.Turret => new TurretMountedWeapon(CreateWeapon(config, unitView), unitView, _turretViewFactory, _gunPointViewFactory),
                _ => throw new ArgumentOutOfRangeException(nameof(config), config, "A not-existent weapon mount type is provided")
            };
        }
        
        private Weapon CreateWeapon(MountedWeaponConfig config, UnitView unitView) => _weaponFactory.Create(config.MountedWeapon, unitView.UnitType);
    }
}