namespace Gameplay.Shooting
{
    public class FrontalMountedWeapon : MountedWeapon
    {

        public FrontalMountedWeapon(Weapon weapon) : base(weapon)
        {
        }

        public override void CommenceFiring()
        {
            Weapon.CommenceFiring();
        }
    }
}