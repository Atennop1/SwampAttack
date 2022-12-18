using System;
using SwampAttack.Runtime.Model.Weapons.Types;

namespace SwampAttack.Runtime.Model.Weapons.Data
{
    public class WeaponTypeIdentifier
    {
        public WeaponType Identify(IWeapon weapon)
        {
            if (weapon.GetType() == typeof(Pistol))
                return WeaponType.Pistol;
            
            if (weapon.GetType() == typeof(Shotgun))
                return WeaponType.Shotgun;

            throw new Exception("Type for this weapon doesn't exist");
        }
    }
}