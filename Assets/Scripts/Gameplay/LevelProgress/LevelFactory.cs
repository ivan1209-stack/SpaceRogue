using Gameplay.Services;
using System;
using Zenject;

namespace Gameplay.Factories
{
    public class LevelFactory : PlaceholderFactory<int, Level>
    {
        //TODO ?? LevelCreatedEventArgs
        public event Action LevelCreated;

        public override Level Create(int param)
        {
            LevelCreated?.Invoke();
            return base.Create(param);
        }
    }
}