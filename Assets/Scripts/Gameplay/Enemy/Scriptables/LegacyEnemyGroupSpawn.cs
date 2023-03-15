using System;
using UnityEngine;

namespace Gameplay.Enemy.Scriptables
{
    [Serializable]
    public sealed class LegacyEnemyGroupSpawn
    {
        [field: SerializeField, Min(1)] public int GroupCount { get; private set; }
    }
}