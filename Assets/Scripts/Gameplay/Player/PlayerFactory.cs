using System;
using Gameplay.Events;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public sealed class PlayerFactory : PlaceholderFactory<Vector2, Player>
    {
        public event Action<PlayerSpawnedEventArgs> PlayerSpawned = _ => { };

        public override Player Create(Vector2 spawnPoint)
        {
            var player = base.Create(spawnPoint);
            PlayerSpawned.Invoke(new PlayerSpawnedEventArgs
            {
                Transform = player.PlayerView.transform
            });
            return player;
        }
    }
}