using Abstracts;
using Gameplay.Abstracts;

namespace Gameplay.Shooting
{
    public class UnmountedWeapon : MountedWeapon
    {
        public UnmountedWeapon(Weapon weapon, UnitView unitView) : base(weapon, unitView) { }
        
        public override void CommenceFiring()
        {
            //Does nothing, weapon is unmounted
        }
    }
}