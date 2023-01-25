using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;

namespace SwampAttack.Factories
{
    public interface IWeaponProductProductsFactory
    {
        IProduct<IProduct<IWeapon>> Create(WeaponSavingData weaponSavingData);
    }
}