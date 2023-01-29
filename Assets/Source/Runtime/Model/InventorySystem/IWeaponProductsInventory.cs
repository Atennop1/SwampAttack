using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;

namespace SwampAttack.Model.InventorySystem
{
    public interface IWeaponProductsInventory : IInventory<IInventorySlot<IProduct<IWeapon>>>
    {
        IProduct<IWeapon> SelectedProduct { get; }
        void Select(IProduct<IWeapon> product);
    }
}