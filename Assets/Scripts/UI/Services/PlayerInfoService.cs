using Gameplay.Events;
using Gameplay.Services;
using System;
using UI.Game;

namespace UI.Services
{
    public sealed class PlayerInfoService : IDisposable
    {
        private readonly CurrentLevelProgress _currentLevelProgress;
        public PlayerStatusBarView PlayerStatusBarView { get; private set; }
        public PlayerSpeedometerView PlayerSpeedometerView { get; private set; }
        public PlayerWeaponView PlayerWeaponView { get; private set; }

        public PlayerInfoService(CurrentLevelProgress currentLevelProgress, PlayerInfoView playerInfoView)
        {
            _currentLevelProgress = currentLevelProgress;
            PlayerStatusBarView = playerInfoView.PlayerStatusBarView;
            PlayerSpeedometerView = playerInfoView.PlayerSpeedometerView;
            PlayerWeaponView = playerInfoView.PlayerWeaponView;

            ShowPlayerInfo(false);

            _currentLevelProgress.PlayerSpawned += OnPlayerSpawned;
        }

        public void Dispose()
        {
            _currentLevelProgress.PlayerSpawned -= OnPlayerSpawned;
        }

        private void OnPlayerSpawned(PlayerSpawnedEventArgs obj)
        {
            ShowPlayerInfo(true);
        }

        private void ShowPlayerInfo(bool enable)
        {
            PlayerStatusBarView.gameObject.SetActive(enable);
            PlayerSpeedometerView.gameObject.SetActive(enable);
            PlayerWeaponView.gameObject.SetActive(enable);
        }
    }
}