using NUnit.Framework;
using NUnit.Framework.Internal;
using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Tests.NullComponents.Products;
using SwampAttack.Tests.NullComponents.Weapons;

namespace SwampAttack.Tests.Inventory.WeaponProductsInventoryTests
{
    public class CreateInventoryTest
    {
        [Test]
        public void CantCreateIncorrectInventory()
        {
            var errors = 0;
            
            try { var inventory = new WeaponProductsInventory<Test>(new NullWeaponsView(), new NullWeaponProductsFactory(), -1); }
            catch { errors++; }
            
            try { var inventory = new WeaponProductsInventory<Test>(new NullWeaponsView(), null, 1); }
            catch { errors++; }
            
            try { var inventory = new WeaponProductsInventory<Test>(null, new NullWeaponProductsFactory(), 1); }
            catch { errors++; }
            
            Assert.That(errors == 3);
        }
    }
}