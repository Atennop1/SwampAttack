using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Shop.ProductsLists;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Types;
using SwampAttack.Tests.NullComponents.Inventory;
using SwampAttack.Tests.NullComponents.Products;

namespace SwampAttack.Tests.Shop.WeaponProductsListTests
{
    public class ProductsListOperationsTest
    {
        private WeaponProductsList<Test> _weaponProductsList;
        
        [SetUp]
        public void Setup()
        {
            _weaponProductsList = new WeaponProductsList<Test>(new ProductsList<IProduct<IWeapon>>
                (new NullProductsListView<IProduct<IWeapon>>(), new List<IProductCell<IProduct<IWeapon>>>()), new NullWeaponProductProductsFactory());
        }

        [Test]
        public void IsAddingValid()
        {
            (_weaponProductsList.Cells as List<IProductCell<IProduct<IWeapon>>>)?.Clear();
            
            var addingProduct = new Product<IProduct<IWeapon>>
                (new Product<IWeapon>(new Pistol(new NullBulletsFactory(), new NullWeaponBulletsView(), 1), new NullProductData()), 
                new NullProductData());
            
            _weaponProductsList.Add(addingProduct);
            var newProductsList = new WeaponProductsList<Test>(new ProductsList<IProduct<IWeapon>>
                (new NullProductsListView<IProduct<IWeapon>>(), new List<IProductCell<IProduct<IWeapon>>>()), new NullWeaponProductProductsFactory());
            
            Assert.That(addingProduct.Item.Item.GetType() == newProductsList.Cells[0].Product.Item.Item.GetType());
        }

        [Test]
        public void IsTakingValid()
        {
            var product = new Product<IProduct<IWeapon>>
            (new Product<IWeapon>(new Pistol(new NullBulletsFactory(), new NullWeaponBulletsView(), 1), new NullProductData()), 
                new NullProductData());
            
            _weaponProductsList.Add(product);
            var newProductsList = new WeaponProductsList<Test>(new ProductsList<IProduct<IWeapon>>
                (new NullProductsListView<IProduct<IWeapon>>(), new List<IProductCell<IProduct<IWeapon>>>()), new NullWeaponProductProductsFactory());
            
            _weaponProductsList.Take(product);
            newProductsList = new WeaponProductsList<Test>(new ProductsList<IProduct<IWeapon>>
                (new NullProductsListView<IProduct<IWeapon>>(), new List<IProductCell<IProduct<IWeapon>>>()), new NullWeaponProductProductsFactory());

            Assert.That(_weaponProductsList.Cells.Count(cell => cell.Product == product) == 0 && 
                        newProductsList.Cells.Count(cell => cell.Product == product) == 0);
        }
    }
}