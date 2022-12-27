using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SwampAttack.Runtime.Model.Shop.Clients;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Shop;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Shop.ProductsLists;
using SwampAttack.Tests.NullComponents.Inventory;
using SwampAttack.Tests.NullComponents.Products;
using SwampAttack.Tests.NullComponents.Wallet;

namespace SwampAttack.Tests.Shop.Client
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
            var productsList = new ProductsList<IWeapon>(new NullProductsListView<IWeapon>(), new List<IProductCell<IWeapon>> { new ProductCell<IWeapon>(product) });
            
            client.Buy(product, productsList);
            Assert.That(inventory.Items.Contains(weapon));
        }
    }
}