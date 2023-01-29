using SwampAttack.Model.InventorySystem;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;

namespace SwampAttack.View.Shop
{
    public class WeaponProductsListView : ProductsListView<IInventorySlot<IProduct<IWeapon>>> { }
}