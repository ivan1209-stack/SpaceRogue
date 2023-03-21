using Gameplay.Damage;
using Gameplay.Survival;
using System;

namespace Gameplay.Space.SpaceObjects
{
    public class DamageOnTouchView : AreaEffectView, IDamageableView
    {
        public event Action<DamageModel> DamageTaken;

        public void TakeDamage(IDamagingView damageComponent)
        {
            throw new NotImplementedException();
        }
    }
}