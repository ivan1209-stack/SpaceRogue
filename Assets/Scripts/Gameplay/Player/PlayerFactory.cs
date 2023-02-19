using System;
using Gameplay.Events;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public class PlayerFactory : PlaceholderFactory<Vector2, Player>
    {
        public event Action<PlayerSpawnedEventArgs> PlayerSpawned = _ => { };

        public override Player Create(Vector2 param)
        {
            var player = base.Create(param);
            PlayerSpawned.Invoke(new PlayerSpawnedEventArgs
            {
                Transform = player.PlayerView.transform
            });
            return player;
        }
    }
}