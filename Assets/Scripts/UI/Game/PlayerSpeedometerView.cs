using UI.Common;
using UnityEngine;

namespace UI.Game
{
    public sealed class PlayerSpeedometerView : MonoBehaviour
    {
        [field: SerializeField] public TextView SpeedometerTextView { get; private set; }

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);

        public void Init(string text) => SpeedometerTextView.Init(text);
        public void UpdateText(string text) => SpeedometerTextView.UpdateText(text);
    }
}