using System;
using Gameplay.Events;
using Gameplay.Player;

namespace Gameplay.Services
{
    public sealed class CurrentLevelProgress : IDisposable
    {
        private readonly PlayerFactory _playerFactory;
        
        public event Action<PlayerSpawnedEventArgs> PlayerSpawned = (_) => { };
        public event Action PlayerDestroyed = () => { };

        public CurrentLevelProgress(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
            
            _playerFactory.PlayerSpawned += OnPlayerSpawned;
        }

        public void Dispose()
        {
            _playerFactory.PlayerSpawned -= OnPlayerSpawned;
        }

        private void OnPlayerSpawned(PlayerSpawnedEventArgs args)
        {
            PlayerSpawned.Invoke(args);
        }
    }
}