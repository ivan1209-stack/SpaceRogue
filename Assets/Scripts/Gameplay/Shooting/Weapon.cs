using UnityEngine;

namespace Gameplay.Shooting
{
    public abstract class Weapon
    {
        public abstract void CommenceFiring(Vector2 bulletPosition, Quaternion turretDirection);
    }
}