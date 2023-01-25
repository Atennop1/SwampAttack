using SwampAttack.Model.Weapons;

namespace SwampAttack.Factories
{
    public interface IWeaponsFactory
    {
        IWeapon Create(WeaponSavingData savingData);
    }
}