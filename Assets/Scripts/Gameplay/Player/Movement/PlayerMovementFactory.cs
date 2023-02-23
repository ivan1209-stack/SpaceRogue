using System;
using Zenject;

namespace Gameplay.Player.Movement
{
    public class PlayerMovementFactory : PlaceholderFactory<PlayerView, PlayerMovement>
    {
        public event Action<PlayerMovement> PlayerMovementCreated = _ => { };

        public override PlayerMovement Create(PlayerView param)
        {
            var playerMovement = base.Create(param);
            PlayerMovementCreated?.Invoke(playerMovement);
            return playerMovement;
        }
    }
}