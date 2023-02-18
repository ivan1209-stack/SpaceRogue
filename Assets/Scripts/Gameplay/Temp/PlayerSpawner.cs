using Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Gameplay.Temp
{
    public class PlayerSpawner : IInitializable
    {
        private readonly PlayerFactory _playerFactory;

        public PlayerSpawner(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        public void Initialize()
        {
            _playerFactory.Create(new Vector2(0, 0));
        }
    }
}