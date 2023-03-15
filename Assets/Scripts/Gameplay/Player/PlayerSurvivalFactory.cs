using System;
using Gameplay.Survival;
using Zenject;

namespace Gameplay.Player
{
    public sealed class PlayerSurvivalFactory : PlaceholderFactory<EntitySurvival>
    {
        private readonly EntitySurvivalFactory _entitySurvivalFactory;
        private readonly EntitySurvivalConfig _playerSurvivalConfig;

        public event Action<EntitySurvival> PlayerSurvivalCreated = _ => { };

        public PlayerSurvivalFactory(EntitySurvivalFactory entitySurvivalFactory, EntitySurvivalConfig playerSurvivalConfig)
        {
            _entitySurvivalFactory = entitySurvivalFactory;
            _playerSurvivalConfig = playerSurvivalConfig;
        }

        public override EntitySurvival Create()
        {
            var playerSurvival = _entitySurvivalFactory.Create(_playerSurvivalConfig);
            PlayerSurvivalCreated.Invoke(playerSurvival);
            return playerSurvival;
        }
    }
}