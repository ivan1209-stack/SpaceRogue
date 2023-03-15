using UnityEngine;

namespace Gameplay.Shooting.Weapons
{
    public sealed class NullGun : Weapon
    {
        public override void CommenceFiring(Vector2 bulletPosition, Quaternion turretDirection)
        {
            Debug.Log($"None-gun has fired, bullet position {bulletPosition}, direction {turretDirection.eulerAngles}!");
        }
    }
}