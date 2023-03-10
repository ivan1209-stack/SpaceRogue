namespace Gameplay.Shooting
{
    public class TurretMountedWeapon : MountedWeapon
    {
        public TurretMountedWeapon(Weapon weapon) : base(weapon)
        {
        }

        public override void CommenceFiring()
        {
            Weapon.CommenceFiring();
        }
    }
}