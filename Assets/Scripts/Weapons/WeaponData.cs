using SwampAttack.Input;

namespace SwampAttack.Weapons
{
    public readonly struct WeaponData
    {
        public readonly IWeaponInput Input;
        public readonly IWeapon Weapon;
        
        public WeaponData(IWeaponInput input, IWeapon weapon)
        {
            Input = input;
            Weapon = weapon;
        }
    }
}