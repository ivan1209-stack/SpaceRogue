using Gameplay.Health;
using Scriptables;
using Scriptables.Health;
using Zenject;

namespace Gameplay.Player
{
    public class PlayerSurvivalFactory : PlaceholderFactory<EntitySurvival>
    {
        private readonly EntitySurvivalFactory _entitySurvivalFactory;
        private readonly EntitySurvivalConfig _playerSurvivalConfig;

        public PlayerSurvivalFactory(EntitySurvivalFactory entitySurvivalFactory, EntitySurvivalConfig playerSurvivalConfig)
        {
            _entitySurvivalFactory = entitySurvivalFactory;
            _playerSurvivalConfig = playerSurvivalConfig;
        }

        public override EntitySurvival Create()
        {
            return _entitySurvivalFactory.Create(_playerSurvivalConfig);
        }
    }
}