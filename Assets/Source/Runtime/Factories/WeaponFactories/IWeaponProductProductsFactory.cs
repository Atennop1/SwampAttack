using SwampAttack.Model.InventorySystem;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;

namespace SwampAttack.Factories
{
    public interface IWeaponProductProductsFactory
    {
        IProduct<IInventorySlot<IProduct<IWeapon>>> Create(WeaponSavingData weaponSavingData);
    }
}