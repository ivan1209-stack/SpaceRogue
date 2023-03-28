using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects.Views;
using Object = UnityEngine.Object;
using Gameplay.Mechanics.Timer;
using Gameplay.Damage;
using Services;

namespace Gameplay.Space.SpaceObjects.SpaceObjectsEffects
{
    public sealed class DamageAuraEffect : SpaceObjectEffect
    {
        private readonly DamageAuraView _view;
        private Timer _cooldownTimer { get; set; }

        public DamageAuraEffect(DamageAuraView view, DamageAuraConfig config)
        {
            _cooldownTimer = new(config.DamageInterval, new Updater());
            _view = view;
            _view.Init(new DamageModel(config.Damage), _cooldownTimer);
        }

        public override void Dispose()
        {
            Object.Destroy(_view.gameObject);
            _cooldownTimer.Dispose();
        }
    }
}