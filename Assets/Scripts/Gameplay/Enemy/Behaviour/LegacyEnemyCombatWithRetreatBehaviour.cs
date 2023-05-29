using Gameplay.Enemy.Movement;
using Gameplay.Player;
using Gameplay.Shooting;
using Utilities.Reactive.SubscriptionProperty;

namespace Gameplay.Enemy.Behaviour
{
    public sealed class LegacyEnemyCombatWithRetreatBehaviour : LegacyEnemyCombatBehaviour
    {
        private readonly EnemyState _lastEnemyState;

        public LegacyEnemyCombatWithRetreatBehaviour(
            SubscribedProperty<EnemyState> enemyState, EnemyView view, PlayerController playerController,
            EnemyInput inputController, Weapon frontalTurret, EnemyBehaviourConfig config,
            EnemyState lastEnemyState) 
            : base(enemyState, view, playerController, inputController, frontalTurret, config)
        {
            _lastEnemyState = lastEnemyState;
        }

        protected override void DetectPlayer()
        {
            if (_distance > Config.PlayerDetectionRadius)
            {
                _inZone = false;
                ExitCombat();
            }
            else
            {
                _inZone = true;
            }
        }

        private void ExitCombat()
        {
            ChangeState(_lastEnemyState);
        }
    }
}