using System;
using Gameplay.Events;
using Gameplay.Mechanics.Timer;
using Gameplay.Player;
using Services;
using UnityEngine;

namespace Gameplay.Services
{
    public sealed class PlayerLocator : IDisposable
    {
        private readonly Updater _updater;
        private readonly Timer _timer;
        private readonly PlayerFactory _playerFactory;

        private Transform _playerTransform;

        public event Action<Vector3> PlayerPosition = _ => { };

        public PlayerLocator(
            Updater updater,
            TimerFactory timerFactory,
            PlayerFactory playerFactory)
        {
            _updater = updater;
            _timer = timerFactory.Create(1);
            _playerFactory = playerFactory;

            _playerFactory.PlayerSpawned += OnPlayerSpawned;
        }

        public void Dispose()
        {
            _updater.UnsubscribeFromUpdate(Locator);
            _playerFactory.PlayerSpawned -= OnPlayerSpawned;
        }

        private void Locator()
        {
            if(_playerTransform == null)
            {
                Dispose();
                return;
            }

            if (_timer.IsExpired)
            {
                _timer.Start();
                PlayerPosition.Invoke(_playerTransform.position);
            }
        }

        private void OnPlayerSpawned(PlayerSpawnedEventArgs args)
        {
            _playerTransform = args.Transform;
            _updater.SubscribeToUpdate(Locator);
        }
    }
}