using Scriptables;
using Services;
using UI.Game;
using UnityEngine;

namespace UI.Services
{
    public sealed class LevelInfoService
    {
        private readonly LevelNumberView _levelNumberView;
        private readonly EnemiesCountView _enemiesCountView;
        private readonly LevelProgressConfig _levelProgressConfig;

        public int EnemiesCountToWin { get; private set; }

        public LevelInfoService(PlayerDataService playerDataService, LevelInfoView levelInfoView, 
            LevelProgressConfig levelProgressConfig)
        {
            _levelNumberView = levelInfoView.LevelNumberView;
            _enemiesCountView = levelInfoView.EnemiesCountView;
            _levelProgressConfig = levelProgressConfig;

            _levelNumberView.InitNumber(playerDataService.CompletedLevels + 1);

            ShowEnemiesCount(false);

            //TODO Get value from SpaceGenerator
            //SetEnemiesSpawnedCount
        }

        public void SetEnemiesSpawnedCount(int enemiesCount)
        {
            ShowEnemiesCount(true);
            EnemiesCountToWin = Mathf.Clamp(_levelProgressConfig.EnemiesCountToWin, 1, enemiesCount);
            _enemiesCountView.Init(0, EnemiesCountToWin);
        }

        private void ShowEnemiesCount(bool enable)
        {
            _enemiesCountView.gameObject.SetActive(enable);
        }
    }
}