using NUnit.Framework;
using SwampAttack.Model.InventorySystem;
using SwampAttack.Model.Weapons;

namespace SwampAttack.Inventory
{
    public class CreateInventoryTests
    {
        [Test]
        public void CantCreateIncorrectInventory()
        {
            try { var inventory = new Inventory<IWeapon>(-1); }
            catch { Assert.Pass(); }
        }
    }
}