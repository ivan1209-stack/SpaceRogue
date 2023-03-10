namespace Gameplay.Shooting
{
    public class UnmountedWeapon : MountedWeapon
    {
        public UnmountedWeapon(Weapon weapon) : base(weapon) { }
        
        public override void CommenceFiring()
        {
            //Does nothing, weapon is unmounted
        }
    }
}