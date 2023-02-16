using Gameplay.Events;
using Gameplay.Minimap;
using Gameplay.Services;
using Scriptables;
using Services;
using System;
using UI.Game;
using UnityEngine;

namespace UI.Services
{
    public sealed class MinimapService : IDisposable
    {
        private const int CameraZAxisOffset = -1;

        private readonly Updater _updater;
        private readonly CurrentLevelProgress _currentLevelProgress;
        private readonly PlayerInput _playerInput;
        private readonly RectTransform _mainRectTransform;
        private readonly Camera _minimapCamera;
        private readonly MinimapView _minimapView;
        private readonly MinimapConfig _minimapConfig;

        private readonly float _mapCameraSize;
        private readonly Transform _minimapCameraTransform;
        private readonly RectTransform _minimapRectTransform;
        private Transform _playerTransform;

        private readonly float _anchoredPositionX;
        private readonly float _anchoredPositionY;

        private bool _isButtonPressed;

        public MinimapService(Updater updater, CurrentLevelProgress currentLevelProgress, PlayerInput playerInput,
            MainCanvas mainCanvas, MinimapCamera minimapCamera, MinimapView minimapView, MinimapConfig minimapConfig)
        {
            _updater = updater;
            _currentLevelProgress = currentLevelProgress;
            _playerInput = playerInput;
            _mainRectTransform = (RectTransform)mainCanvas.transform;
            _minimapCamera = minimapCamera.GetComponent<Camera>();
            _minimapView = minimapView;
            _minimapConfig = minimapConfig;

            //TODO Get value from SpaceGenerator
            //mapCameraSize
            _mapCameraSize = 512;

            _minimapCameraTransform = _minimapCamera.transform;
            _minimapRectTransform = (RectTransform)_minimapView.transform;
            _anchoredPositionX = _minimapRectTransform.anchoredPosition.x;
            _anchoredPositionY = _minimapRectTransform.anchoredPosition.y;

            MinimapInit(_minimapConfig.MinimapCameraSize, _minimapConfig.MinimapColor, _minimapConfig.MinimapAlpha);

            //For Test
            //OnPlayerSpawned(new() { Transform = _minimapCamera.transform });
            _currentLevelProgress.PlayerSpawned += OnPlayerSpawned;
            _currentLevelProgress.PlayerDestroyed += OnPlayerDestroyed;
        }

        public void Dispose()
        {
            _updater.UnsubscribeFromUpdate(FollowPlayer);
            _currentLevelProgress.PlayerSpawned -= OnPlayerSpawned;
            _currentLevelProgress.PlayerDestroyed -= OnPlayerDestroyed;
        }

        private void OnPlayerSpawned(PlayerSpawnedEventArgs eventArgs)
        {
            _playerTransform = eventArgs.Transform;
            _playerInput.MapInput += MapInput;
            _updater.SubscribeToUpdate(FollowPlayer);
        }

        private void OnPlayerDestroyed()
        {
            _playerInput.MapInput -= MapInput;
            ReturnToMinimap();
            _updater.UnsubscribeFromUpdate(FollowPlayer);
            _playerTransform = null;
        }

        private void MinimapInit(float cameraSize, Color color, float alpha)
        {
            _minimapCamera.orthographicSize = cameraSize;
            _minimapCamera.backgroundColor = color;
            _minimapView.SetColor(color);
            _minimapView.SetAlpha(alpha);
        }

        private void FollowPlayer()
        {
            if (_playerTransform == null || _isButtonPressed)
            {
                return;
            }

            var position = _playerTransform.position;
            _minimapCameraTransform.position = new(position.x, position.y, position.z + CameraZAxisOffset);
        }

        private void MapInput(bool mapInput)
        {
            if (mapInput & !_isButtonPressed)
            {
                _isButtonPressed = mapInput;

                _updater.UnsubscribeFromUpdate(FollowPlayer);
                BecomeMap();
                return;
            }

            if (_isButtonPressed == mapInput)
            {
                return;
            }
            _isButtonPressed = mapInput;
            ReturnToMinimap();
            _updater.SubscribeToUpdate(FollowPlayer);
        }

        private void BecomeMap()
        {
            _minimapCameraTransform.position = new(0, 0, CameraZAxisOffset);
            _minimapCamera.orthographicSize = _mapCameraSize;

            var newHeight = _mainRectTransform.sizeDelta.y - _anchoredPositionY * 2;
            var newAnchoredPositionX = _mainRectTransform.sizeDelta.x / 2 - newHeight / 2;
            _minimapRectTransform.sizeDelta = new(0, newHeight);
            _minimapRectTransform.anchoredPosition = new(newAnchoredPositionX, _anchoredPositionY);
        }

        private void ReturnToMinimap()
        {
            _minimapCamera.orthographicSize = _minimapConfig.MinimapCameraSize;
            _minimapRectTransform.sizeDelta = new(0, _minimapConfig.MinimapHeight);
            _minimapRectTransform.anchoredPosition = new(_anchoredPositionX, _anchoredPositionY);
        }
    }
}