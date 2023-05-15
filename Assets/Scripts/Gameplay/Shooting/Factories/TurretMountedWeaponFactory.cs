using Gameplay.Abstracts;
using Gameplay.Shooting.Scriptables;
using Zenject;


namespace Gameplay.Shooting.Factories
{
    public class TurretMountedWeaponFactory : PlaceholderFactory<Weapon, EntityView, TurretViewFactory, GunPointViewFactory, TurretConfig, TurretMountedWeapon>
    {
    }
}