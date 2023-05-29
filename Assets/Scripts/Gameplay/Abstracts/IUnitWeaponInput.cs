using System;

namespace Gameplay.Abstracts
{
    public interface IUnitWeaponInput
    {
        public event Action<bool> PrimaryFireInput;
        public event Action<bool> ChangeWeaponInput;
    }
}