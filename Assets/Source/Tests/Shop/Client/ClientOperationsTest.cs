using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SwampAttack.Model.InventorySystem;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;
using SwampAttack.NullComponents;

namespace SwampAttack.Shop.Client
{
    public class ClientOperationsTest
    {
        [Test]
        public void IsBuyingValid()
        {
            var inventory = new Inventory<IWeapon>(1);
            var client = new Client<IWeapon>(new NullWallet(10), inventory);
            
            var weapon = new Weapon(new NullBulletsFactory(), new NullWeaponBulletsView(), 1);
            var product = new Product<IWeapon>(weapon, new NullProductData());
            var productsList = new ProductsList<IWeapon>(new List<IProductCell<IWeapon>> { new ProductCell<IWeapon>(product) });
            
            client.Buy(product, productsList);
            Assert.That(inventory.Items.Contains(weapon));
        }
    }
}