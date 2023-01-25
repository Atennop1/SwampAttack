using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;

namespace SwampAttack.Factories
{
    public interface IWeaponProductsFactory
    {
        IProduct<IWeapon> Create(WeaponSavingData savingData);
    }
}