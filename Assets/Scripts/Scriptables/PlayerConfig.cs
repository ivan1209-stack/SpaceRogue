using Gameplay.Movement;
using Gameplay.Player.Inventory;
using Scriptables.Health;
using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configs/Player/" + nameof(PlayerConfig))]
    public sealed class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public PlayerInventoryConfig Inventory { get; private set; }
        [field: SerializeField] public UnitMovementConfig UnitMovement { get; private set; }
        [field: SerializeField] public EntitySurvivalConfig Survival { get; private set; }
    }
}