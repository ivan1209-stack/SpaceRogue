using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = nameof(GameBackgroundConfig), menuName = "Configs/Background/" + nameof(GameBackgroundConfig))]
    public sealed class GameBackgroundConfig : ScriptableObject
    {
        [field: SerializeField] public float BackCoefficient { get; private set; }
        [field: SerializeField] public float MidCoefficient { get; private set; }
        [field: SerializeField] public float ForeCoefficient { get; private set; }

        [field: SerializeField] public float NebulaBackCoefficient { get; private set; }
        [field: SerializeField] public float NebulaForeCoefficient { get; private set; }
    }
}