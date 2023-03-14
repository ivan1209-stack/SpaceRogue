using System;
using Gameplay.Space.SpaceObjects.Scriptables;
using UnityEngine;

namespace Scriptables
{
    [Serializable]
    public sealed class LevelPreset
    {
        [field: SerializeField] public SpaceConfig SpaceConfig{ get; private set; }
        [field: SerializeField] public int EnemiesCountToWin { get; private set; } = 10;
    }
}