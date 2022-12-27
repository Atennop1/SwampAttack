using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SwampAttack.Runtime.Model.Shop;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Shop.ProductsLists;
using SwampAttack.Tests.NullComponents.Products;
using SwampAttack.Tests.NullComponents.Weapons;

namespace SwampAttack.Tests.Shop
{
    public class ProductsListOperationsTest
    {
        private ProductsList<NullWeapon> _productsList;
        private Product<NullWeapon> _weaponProduct;
        
        [SetUp]
        public void Setup()
        {
            var weapon = new NullWeapon();
            _weaponProduct = new Product<NullWeapon>(weapon, new NullProductData());
            _productsList = new ProductsList<NullWeapon>(new NullProductsListView<NullWeapon>(),new List<IProductCell<NullWeapon>>());
        }

        [Test]
        public void IsAddingCorrect()
        {
            var errors = 0;

            _productsList.Add(_weaponProduct);
            if (_productsList.Cells.Count(cell => cell.Product == _weaponProduct) != 1 ||
                _productsList.Cells.Where(cell => cell.Product == _weaponProduct).ToArray()[0].Count != 1) errors++;
            
            _productsList.Add(_weaponProduct);
            if (_productsList.Cells.Where(cell => cell.Product == _weaponProduct).ToArray()[0].Count != 2)
                errors++;
            
            Assert.That(errors == 0);
        }

        [Test]
        public void CantAddInvalidProduct()
        {
            var errors = 0;
            
            try { _productsList.Add(_weaponProduct, -1); }
            catch { errors++; }
            
            try { _productsList.Add(null); }
            catch { errors++; }
            
            Assert.That(errors == 2);
        }

        [Test]
        public void IsTakingCorrect()
        {
            var errors = 0;
            
            try { _productsList.Take(_weaponProduct); }
            catch { errors++; }
            
            _productsList.Add(_weaponProduct);
            try { _productsList.Take(_weaponProduct, 2); }
            catch { errors++; }
            
            Assert.That(errors == 2);
        }

        [Test]
        public void CantTakeInvalidProduct()
        {
            var errors = 0;
            
            try { _productsList.Take(_weaponProduct, -1); }
            catch { errors++; }
            
            try { _productsList.Take(null); }
            catch { errors++; }
            
            Assert.That(errors == 2);
        }
    }
}