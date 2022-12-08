using System;
using SwampAttack.Runtime.Model.Input;

namespace SwampAttack.Runtime.Model.Weapons
{
    public readonly struct WeaponUsingInfo
    {
        public readonly IWeaponInput Input;
        public readonly IWeapon Weapon;
        
        public WeaponUsingInfo(IWeaponInput input, IWeapon weapon)
        {
            Input = input ?? throw new ArgumentException("Input can't be null");
            Weapon = weapon ?? throw new ArgumentException("Weapon can't be null");
        }
    }
}