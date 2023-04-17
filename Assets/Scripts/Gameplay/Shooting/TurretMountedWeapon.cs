using Abstracts;
using Gameplay.Abstracts;
using Gameplay.Shooting.Factories;
using UnityEngine;

namespace Gameplay.Shooting
{
    public sealed class TurretMountedWeapon : MountedWeapon
    {
        private readonly TurretView _turretView;
        private readonly Transform _gunPointViewTransform;
        
        public TurretMountedWeapon(Weapon weapon, EntityView entityView, TurretViewFactory turretViewFactory, GunPointViewFactory gunPointViewFactory) : base(weapon, entityView)
        {
            var unitScale = UnitViewTransform.localScale;
            var gunPointPosition = UnitViewTransform.position + UnitViewTransform.TransformDirection(0.6f * Mathf.Max(unitScale.x, unitScale.y) * Vector3.up);
            _turretView = turretViewFactory.Create(UnitViewTransform);
            var turretViewTransform = _turretView.transform;
            var gunPoint = gunPointViewFactory.Create(gunPointPosition, UnitViewTransform.rotation, turretViewTransform);
            _gunPointViewTransform = gunPoint.transform;
        }

        public override void CommenceFiring()
        {
            Weapon.CommenceFiring(_gunPointViewTransform.position, _gunPointViewTransform.rotation);
        }
    }
}