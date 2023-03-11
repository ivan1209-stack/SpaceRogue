using Gameplay.Services;
using System;
using Zenject;

namespace Gameplay.Factories
{
    public sealed class LevelFactory : PlaceholderFactory<int, Level>
    {
        public event Action<Level> LevelCreated = (_) => { };

        public override Level Create(int levelNumber)
        {
            var level = base.Create(levelNumber);
            LevelCreated.Invoke(level);
            return level;
        }
    }
}