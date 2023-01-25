using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;
using SwampAttack.Tests.NullComponents;

namespace SwampAttack.Tests.Shop.WeaponProductsListTests
{
    public class ProductsListOperationsTest
    {
        private WeaponProductsList<Test> _weaponProductsList;
        private NullWeaponProductProductsFactory _factory;
        private NullProductsListView<IProduct<IWeapon>> _view;
        
        [SetUp]
        public void Setup()
        {
            _factory = new NullWeaponProductProductsFactory();
            _view = new NullProductsListView<IProduct<IWeapon>>();
            
            _weaponProductsList = new WeaponProductsList<Test>(new ProductsList<IProduct<IWeapon>>
                (new List<IProductCell<IProduct<IWeapon>>>()), _factory, _view);
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
                (new List<IProductCell<IProduct<IWeapon>>>()), _factory, _view);
            
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
                (new List<IProductCell<IProduct<IWeapon>>>()), _factory, _view);
            
            _weaponProductsList.Take(product);
            newProductsList = new WeaponProductsList<Test>(new ProductsList<IProduct<IWeapon>>
                (new List<IProductCell<IProduct<IWeapon>>>()), _factory, _view);

            Assert.That(_weaponProductsList.Cells.Count(cell => cell.Product == product) == 0 && 
                        newProductsList.Cells.Count(cell => cell.Product == product) == 0);
        }
    }
}