using System;
using System.Collections.Generic;
using Scriptables.Modules;

namespace Gameplay.Player.Inventory
{
    public sealed class PlayerInventory : IDisposable
    {
        private readonly PlayerInventoryConfig _config;
        
        public List<TurretModuleConfig> Turrets => _config.Turrets;

        public PlayerInventory(PlayerInventoryConfig config)
        {
            _config = config;
        }
        
        public void Dispose()
        {
        }
    }
}