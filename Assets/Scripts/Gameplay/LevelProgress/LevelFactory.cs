using Gameplay.Services;
using System;
using Zenject;

namespace Gameplay.Factories
{
    public sealed class LevelFactory : PlaceholderFactory<int, Level>
    {
        public event Action LevelCreated = () => { };

        public override Level Create(int levelNumber)
        {
            LevelCreated.Invoke();
            return base.Create(levelNumber);
        }
    }
}