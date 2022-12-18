using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Data;

namespace SwampAttack.Runtime.Factories.WeaponFactories
{
    public interface IWeaponsFactory
    {
        IWeapon Create(WeaponSavingData savingData);
    }
}