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
            Type = weapon.GetWeaponType();
            Bullets = weapon.Bullets.TryThrowIfLessOrEqualsZero();
        }
    }
}