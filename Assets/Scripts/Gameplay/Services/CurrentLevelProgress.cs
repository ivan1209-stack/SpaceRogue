using System;
using Gameplay.Events;
using Gameplay.LevelProgress;
using Gameplay.Player;

namespace Gameplay.Services
{
    public sealed class CurrentLevelProgress : IDisposable
    {
        private readonly LevelFactory _levelFactory;
        private readonly PlayerFactory _playerFactory;
        
        public event Action<Level> LevelCreated = (_) => { };
        public event Action<int> DefeatedEnemiesCountChange = (_) => { };
        public event Action<PlayerSpawnedEventArgs> PlayerSpawned = (_) => { };
        public event Action PlayerDestroyed = () => { };

        public CurrentLevelProgress(LevelFactory levelFactory, PlayerFactory playerFactory)
        {
            _levelFactory = levelFactory;
            _playerFactory = playerFactory;

            _levelFactory.LevelCreated += OnLevelCreated;
            _playerFactory.PlayerSpawned += OnPlayerSpawned;
        }

        public void Dispose()
        {
            _levelFactory.LevelCreated -= OnLevelCreated;
            _playerFactory.PlayerSpawned -= OnPlayerSpawned;
        }

        private void OnLevelCreated(Level level)
        {
            LevelCreated.Invoke(level);
        }

        private void OnPlayerSpawned(PlayerSpawnedEventArgs args)
        {
            PlayerSpawned.Invoke(args);
        }
    }
}