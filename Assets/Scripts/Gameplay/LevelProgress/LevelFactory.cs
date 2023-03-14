using System;
using Gameplay.Services;
using Zenject;

namespace Gameplay.LevelProgress
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