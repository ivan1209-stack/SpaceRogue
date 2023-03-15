namespace UI.Game
{
    public sealed class PlayerStatusBarView : HealthShieldStatusBarView
    {
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}
