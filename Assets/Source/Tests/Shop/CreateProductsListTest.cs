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
            Assert.Throws<ArgumentException>(() =>
            {
                var productsList = new ProductsList<IWeapon>(null);
            });
        }
    }
}