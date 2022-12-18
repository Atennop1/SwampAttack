using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Player;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.View.Weapons.PlayerWeapons;

namespace SwampAttack.Tests.NullComponents.Weapons
{
    public class NullWeaponsView : IPlayerWeaponsView
    {
        public bool IsVisualized { get; private set; }
        
        public void Init(Player player) { }
        public void Display(IInventory<IProduct<IWeapon>> inventory) => IsVisualized = true;
    }
}