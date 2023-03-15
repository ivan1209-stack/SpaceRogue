using Zenject;

namespace Gameplay.Movement
{
    public sealed class UnitMovementModelFactory : PlaceholderFactory<UnitMovementConfig, UnitMovementModel>
    {
        public override UnitMovementModel Create(UnitMovementConfig config)
        {
            return new UnitMovementModel(config);
        }
    }
}