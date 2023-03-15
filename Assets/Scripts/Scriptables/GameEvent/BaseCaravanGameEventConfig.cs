using Gameplay.Enemy.Scriptables;
using UnityEngine;

namespace Scriptables.GameEvent
{
    public class BaseCaravanGameEventConfig : GameEventConfig
    {
        [field: SerializeField, Header("Base Caravan Settings")] public CaravanConfig CaravanConfig{ get; private set; }
        [field: SerializeField, Min(0)] public float SpawnOffset { get; private set; } = 5;
        [field: SerializeField, Min(0)] public float PathDistance { get; private set; } = 100;
        [field: SerializeField, Header("Enemy Settings")] public LegacyEnemyConfig LegacyEnemyConfig { get; private set; }
        [field: SerializeField, Min(0)] public int EnemyCount { get; private set; } = 1;
    }
}