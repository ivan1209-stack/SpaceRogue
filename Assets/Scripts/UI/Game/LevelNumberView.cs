using UI.Common;
using UnityEngine;

namespace UI.Game
{
    public sealed class LevelNumberView : MonoBehaviour
    {
        [field: SerializeField] public TextView LevelNumber { get; private set; }

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);

        public void InitNumber(float number) => LevelNumber.Init(number.ToString());
        public void UpdateNumber(float number) => LevelNumber.UpdateText(number.ToString());
    }
}