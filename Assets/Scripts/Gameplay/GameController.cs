using Abstracts;
using Gameplay.Enemy;
using Gameplay.GameEvent;
using Gameplay.LevelProgress;
using Gameplay.Player;
using UI.Game;

namespace Gameplay
{
    public sealed class GameController : BaseController
    {
        private readonly GameDataController _gameDataController;
        private readonly GameUIController _gameUIController;
        private readonly PlayerController _playerController;
        private readonly EnemyForcesController _enemyForcesController;
        private readonly GeneralGameEventsController _generalGameEventsController;
        private readonly LevelProgressController _levelProgressController;

        public GameController(GameDataController gameDataController)
        {
            _gameDataController = gameDataController;

            _playerController = new(new(), _gameDataController.PlayerHealthInfo, _gameDataController.PlayerShieldInfo);
            AddController(_playerController);
            _playerController.PlayerDestroyed += OnPlayerDestroyed;

            _enemyForcesController = new(_playerController, new() { new() });
            AddController(_enemyForcesController);

            _generalGameEventsController = new(_playerController);
            AddController(_generalGameEventsController);

            _levelProgressController = new(_gameDataController, _playerController, _enemyForcesController.EnemyViews);
            _levelProgressController.LevelComplete += LevelComplete;
            AddController(_levelProgressController);

        }

        private void OnPlayerDestroyed()
        {
            _gameUIController.AddDestroyPlayerMessage(_gameDataController.CompletedLevels);
        }

        private void LevelComplete(float levelNumber)
        {
            _gameUIController.AddNextLevelMessage(levelNumber);
        }
    }
}