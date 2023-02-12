using System;
using Scriptables;
using UnityEngine;

namespace Gameplay.Services
{
    public class Level : IDisposable
    {
        
        
        private int _remainingEnemies;
        private int _enemiesRequiredToWin;
        
        public Level(int number, LevelProgressConfig levelProgressConfig)
        {
            _remainingEnemies = 0;
            _enemiesRequiredToWin = Mathf.Clamp(levelProgressConfig.EnemiesCountToWin, 1, _remainingEnemies);
        }

        public void Dispose()
        {
            
        }
    }
}