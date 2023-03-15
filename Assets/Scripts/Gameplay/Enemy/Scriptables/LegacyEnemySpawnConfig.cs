using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Enemy.Scriptables
{
    [CreateAssetMenu(fileName = nameof(LegacyEnemySpawnConfig), menuName = "Configs/Enemy/" + nameof(LegacyEnemySpawnConfig))]
    public sealed class LegacyEnemySpawnConfig : ScriptableObject
    {
        [field: SerializeField] public LegacyEnemyConfig LegacyEnemy { get; private set; }
        [field: SerializeField] public List<LegacyEnemyGroupSpawn> EnemyGroupsSpawnPoints { get; private set; }
    }
}