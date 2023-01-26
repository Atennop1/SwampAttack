using NUnit.Framework;
using NUnit.Framework.Internal;
using SwampAttack.Model.InventorySystem;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;
using SwampAttack.Tests.NullComponents;

namespace SwampAttack.Tests.Inventory.WeaponProductsInventoryTests
{
    public class AddItemsTest
    {
        private WeaponProductsInventory<Test> _inventory;
        private NullWeaponsView _view;

        [SetUp]
        public void Setup()
        {
            _view = new NullWeaponsView();
            _inventory = new WeaponProductsInventory<Test>(_view, new NullWeaponProductsFactory(), int.MaxValue);
        }

        [Test]
        public void IsAddingCorrect()
        {
            var countBefore = _inventory.Items.Count;
            _inventory.Add(new Product<IWeapon>(new Pistol(new NullBulletsFactory(), new NullWeaponBulletsView(), 1), new NullProductData()), 4);
            Assert.That(countBefore + 4 == _inventory.Items.Count);
        }

        [Test]
        public void IsVisualizingCorrect()
        {
            if (!_inventory.IsFull)
                _inventory.Add(new Product<IWeapon>(new Pistol(new NullBulletsFactory(), new NullWeaponBulletsView(), 1), new NullProductData()));
            
            Assert.That(_view.IsVisualized);
        }

        [Test]
        public void IsSavingValid()
        {
            _inventory.Clear();
            
            _inventory.Add(new Product<IWeapon>(new Shotgun(new NullBulletsFactory(), new NullWeaponBulletsView(), 1), new NullProductData()));
            _inventory.Add(new Product<IWeapon>(new Pistol(new NullBulletsFactory(), new NullWeaponBulletsView(), 1), new NullProductData()));

            var newInventory = new WeaponProductsInventory<Test>(_view, new NullWeaponProductsFactory(), int.MaxValue);
            Assert.That(_inventory.Items.Count == newInventory.Items.Count &&
                        (_inventory.Items.Count == 0 || 
                        (_inventory.Items[^1].Item.GetType() == newInventory.Items[^1].Item.GetType() &&
                        _inventory.Items[^2].Item.GetType() == newInventory.Items[^2].Item.GetType())));
        }
    }
}