using System.Collections.Generic;
using Scriptables;
using UnityEngine;

namespace Gameplay.Enemy.Scriptables
{
    [CreateAssetMenu(fileName = nameof(EnemyGroupConfig), menuName = "Configs/Enemy/" + nameof(EnemyGroupConfig))]
    public class EnemyGroupConfig : ScriptableObject
    {
        [field: SerializeField] public List<WeightConfig<EnemySquadConfig>> Squads { get; private set; }
    }
}