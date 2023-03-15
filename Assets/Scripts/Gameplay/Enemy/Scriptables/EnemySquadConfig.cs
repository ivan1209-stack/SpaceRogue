using System.Collections.Generic;
using Scriptables;
using UnityEngine;

namespace Gameplay.Enemy.Scriptables
{
    [CreateAssetMenu(fileName = nameof(EnemySquadConfig), menuName = "Configs/Enemy/" + nameof(EnemySquadConfig))]
    public class EnemySquadConfig : ScriptableObject
    {
        [field: SerializeField] public List<WeightConfig<EnemyConfig>> EnemyTypes { get; private set; }
        [field: SerializeField, Min(1)] public int EnemyCount { get; private set; }
    }
}