using System;
using SwampAttack.Tools;

namespace SwampAttack.Model.Weapons
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