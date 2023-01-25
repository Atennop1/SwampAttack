using SwampAttack.Model.InventorySystem;
using SwampAttack.Model.Player;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;

namespace SwampAttack.View.Weapons
{
    public interface IPlayerWeaponsView
    {
        void Init(Player player);
        void Display(IInventory<IProduct<IWeapon>> inventory);
    }
}