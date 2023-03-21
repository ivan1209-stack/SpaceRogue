using System.Collections.Generic;
using Scriptables;
using UnityEngine;

namespace Gameplay.Enemy.Scriptables
{
    [CreateAssetMenu(fileName = nameof(EnemySpawnConfig), menuName = "Configs/Enemy/" + nameof(EnemySpawnConfig))]
    public class EnemySpawnConfig : ScriptableObject
    {
        [field: SerializeField] public List<WeightConfig<EnemyGroupConfig>> Groups { get; private set; }
    }
}