using System;
using Zenject;

namespace Gameplay.Player.Movement
{
    public sealed class PlayerMovementFactory : PlaceholderFactory<PlayerView, PlayerMovement>
    {
        public event Action<PlayerMovement> PlayerMovementCreated = _ => { };

        public override PlayerMovement Create(PlayerView playerView)
        {
            var playerMovement = base.Create(playerView);
            PlayerMovementCreated.Invoke(playerMovement);
            return playerMovement;
        }
    }
}