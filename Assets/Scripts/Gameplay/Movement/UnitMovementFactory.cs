using Abstracts;
using Gameplay.Player;
using System;
using Zenject;

namespace Gameplay.Movement
{
    public sealed class UnitMovementFactory : PlaceholderFactory<UnitView, IUnitMovementInput, UnitMovementModel, UnitMovement>
    {
        public event Action<UnitMovement> PlayerMovementCreated = _ => { };

        public override UnitMovement Create(UnitView unitView, IUnitMovementInput movementInput, UnitMovementModel model)
        {
            var unitMovement = base.Create(unitView, movementInput, model);

            if (unitView is PlayerView)
            {
                PlayerMovementCreated.Invoke(unitMovement); 
            }

            return unitMovement;
        }
    }
}