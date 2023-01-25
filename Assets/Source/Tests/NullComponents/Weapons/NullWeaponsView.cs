using SwampAttack.Model.InventorySystem;
using SwampAttack.Model.Player;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;
using SwampAttack.View.Weapons;

namespace SwampAttack.Tests.NullComponents
{
    public class NullWeaponsView : IPlayerWeaponsView
    {
        public bool IsVisualized { get; private set; }
        
        public void Init(Player player) { }
        
        public void Display(IInventory<IProduct<IWeapon>> inventory) 
            => IsVisualized = true;
    }
}