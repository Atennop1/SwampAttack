using System;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Data;
using SwampAttack.Runtime.Model.Weapons.Types;

namespace SwampAttack.Runtime.Tools.Extensions
{
    public static class GetWeaponTypeExtension
    {
        public static WeaponType GetWeaponType(this IWeapon weapon)
        {
            if (weapon.GetType() == typeof(Pistol))
                return WeaponType.Pistol;
            
            if (weapon.GetType() == typeof(Shotgun))
                return WeaponType.Shotgun;

            throw new Exception("Type for this weapon doesn't exist");
        }
    }
}