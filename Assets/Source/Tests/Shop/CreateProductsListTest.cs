using System;
using NUnit.Framework;
using SwampAttack.Runtime.Model.Shop;
using SwampAttack.Runtime.Model.Weapons;

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