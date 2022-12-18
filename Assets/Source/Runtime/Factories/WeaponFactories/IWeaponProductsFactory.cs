using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Data;

namespace SwampAttack.Runtime.Factories.WeaponFactories
{
    public interface IWeaponProductsFactory
    {
        IProduct<IWeapon> Create(WeaponSavingData savingData);
    }
}