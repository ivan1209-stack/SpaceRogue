using UnityEngine;

namespace UI.Game
{
    public sealed class LevelInfoView : MonoBehaviour
    {
        [field: SerializeField] public LevelNumberView LevelNumberView { get; private set; }
        [field: SerializeField] public EnemiesCountView EnemiesCountView { get; private set; }
    }
}