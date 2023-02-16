using UnityEngine;

namespace UI.Game
{
    public sealed class PlayerInfoView : MonoBehaviour
    {
        [field: SerializeField] public PlayerStatusBarView PlayerStatusBarView { get; private set; }
        [field: SerializeField] public PlayerSpeedometerView PlayerSpeedometerView { get; private set; }
        [field: SerializeField] public PlayerWeaponView PlayerWeaponView { get; private set; }
    }
}