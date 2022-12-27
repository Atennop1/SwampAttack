using System;
using System.Collections.Generic;
using NUnit.Framework;
using SwampAttack.Runtime.Model.Shop;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.ProductsLists;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Tests.NullComponents.Products;

namespace SwampAttack.Tests.Shop
{
    public class CreateProductsListTest
    {
        [Test]
        public void CantCreateInvalidProductsList()
        {
            var errors = 0;

            try { var productsList = new ProductsList<IWeapon>(null, new List<IProductCell<IWeapon>> { }); }
            catch { errors++; }
            
            try { var productsList = new ProductsList<IWeapon>(new NullProductsListView<IWeapon>(), null); }
            catch { errors++; }
            
            Assert.That(errors == 2);
        }
    }
}