namespace Gameplay.Shooting
{
    public abstract class MountedWeapon
    {
        protected Weapon Weapon { get; set; }
        
        public MountedWeapon(Weapon weapon)
        {
            Weapon = weapon;
        }

        public abstract void CommenceFiring();
    }
}