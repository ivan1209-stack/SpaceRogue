using Zenject;

namespace Gameplay.Movement
{
    public class UnitMovementModelFactory : PlaceholderFactory<UnitMovementConfig, UnitMovementModel>
    {
        public override UnitMovementModel Create(UnitMovementConfig config)
        {
            return new UnitMovementModel(config);
        }
    }
}