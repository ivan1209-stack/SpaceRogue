using Gameplay.Input;
using Gameplay.Movement;
using UnityEngine;

namespace Gameplay.Player.Movement
{
    public class PlayerMovement
    {
        private readonly PlayerInput _playerInput;
        private readonly UnitMovementModel _unitMovementModel;
        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;

        public PlayerMovement(PlayerView playerView, PlayerInput playerInput, UnitMovementModel unitMovementModel)
        {
            _playerInput = playerInput;
            _unitMovementModel = unitMovementModel;
            _rigidbody = playerView.GetComponent<Rigidbody2D>();
            _transform = playerView.transform;
        }
    }
}