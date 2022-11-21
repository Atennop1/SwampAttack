using NUnit.Framework;
using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Weapons;

namespace SwampAttack.Tests.Inventory
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