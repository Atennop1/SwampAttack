using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Player;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;

namespace SwampAttack.Runtime.View.Weapons.PlayerWeapons
{
    public interface IPlayerWeaponsView
    {
        void Init(Player player);
        void Display(IInventory<IProduct<IWeapon>> inventory);
    }
}