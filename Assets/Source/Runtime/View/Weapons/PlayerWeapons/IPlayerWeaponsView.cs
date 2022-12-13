using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;

namespace SwampAttack.Runtime.View.Weapons.PlayerWeapons
{
    public interface IPlayerWeaponsView
    {
        void Display(IInventory<IProduct<IWeapon>> inventory);
    }
}