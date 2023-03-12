using Abstracts;
using UnityEngine;

namespace Gameplay.Shooting
{
    public abstract class MountedWeapon
    {
        protected Weapon Weapon { get; set; }
        protected Transform UnitViewTransform { get; set; }
        
        public MountedWeapon(Weapon weapon, UnitView unitView)
        {
            Weapon = weapon;
            UnitViewTransform = unitView.transform;
        }

        public abstract void CommenceFiring();
    }
}