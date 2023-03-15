using System.Collections.Generic;
using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = nameof(LevelPresetsConfig), menuName = "Configs/Level/" + nameof(LevelPresetsConfig))]
    public sealed class LevelPresetsConfig : ScriptableObject
    {
        [field: SerializeField] public List<LevelPreset> Presets { get; private set; }
    }
}