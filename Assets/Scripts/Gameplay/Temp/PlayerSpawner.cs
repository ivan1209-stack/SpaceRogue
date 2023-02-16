using Gameplay.Factories;
using UnityEngine;
using Zenject;

namespace Gameplay.Temp
{
    public class PlayerSpawner : IInitializable
    {
        private readonly PlayerViewFactory _playerViewFactory;

        public PlayerSpawner(PlayerViewFactory playerViewFactory)
        {
            _playerViewFactory = playerViewFactory;
        }

        public void Initialize()
        {
            _playerViewFactory.Create(new Vector2(0, 0));
        }
    }
}