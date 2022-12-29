using System;
using SwampAttack.Runtime.Tools.Extensions;

namespace SwampAttack.Runtime.Model.Weapons.Data
{
    [Serializable]
    public readonly struct WeaponSavingData
    {
        public readonly WeaponType Type;
        public readonly int Bullets;

        public WeaponSavingData(IWeapon weapon)
        {
            if (weapon.Bullets < 0)
                throw new ArgumentException("Bullets can't be negative number");
            
            if (weapon.Bullets == 0)
                throw new ArgumentException("Bullets can't be zero");

            Type = weapon.GetWeaponType();
            Bullets = weapon.Bullets;
        }
    }
}