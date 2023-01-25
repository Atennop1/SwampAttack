using NUnit.Framework;
using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Tests.NullComponents.Inventory;
using SwampAttack.Tests.NullComponents.Weapons;

namespace SwampAttack.Tests.Inventory
{
    public class AddItemsTests
    {
        private IInventory<IWeapon> _inventory;

        [SetUp]
        public void Setup()
            => _inventory = new Inventory<IWeapon>(int.MaxValue);

        [Test]
        public void CantAddItemsIfInventoryIsFull()
        {
            var weapon = new Weapon(new NullBulletsFactory(), new NullWeaponBulletsView(), 1);
            _inventory.Add(weapon);
            
            try { _inventory.Add(weapon); }
            catch { Assert.Pass(); }
        }
        
        [Test]
        public void CantAddMoreItemsThanInventoryCapacity()
        {
            try { _inventory.Add(new Weapon(new NullBulletsFactory(), new NullWeaponBulletsView(), 1), 2); }
            catch { Assert.Pass(); }
        }

        [Test]
        public void IsAddingCorrect()
        {
            var countBefore = _inventory.Items.Count;
            _inventory.Add(new NullWeapon(), 4);
            Assert.That(countBefore + 4 == _inventory.Items.Count);
        }
    }
}