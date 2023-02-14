using System;
using Gameplay.Events;

namespace Gameplay.Services
{
    public class CurrentLevelProgress
    {
        public event Action<PlayerSpawnedEventArgs> PlayerSpawned = (_) => { };
        public event Action PlayerDestroyed = () => { };
    }
}