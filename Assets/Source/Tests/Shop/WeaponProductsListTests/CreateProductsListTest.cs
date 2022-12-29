using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Shop.ProductsLists;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Tests.NullComponents.Products;

namespace SwampAttack.Tests.Shop.WeaponProductsListTests
{
    public class CreateProductsListTest
    {
        [Test]
        public void CantCreateInvalidProductsList()
        {
            var errors = 0;
            
            try { var weaponProductsList = new WeaponProductsList<Test>(null, new NullWeaponProductProductsFactory(), new NullProductsListView<IProduct<IWeapon>>()); }
            catch { errors++; }
            
            try 
            { 
                var weaponProductsList = new WeaponProductsList<Test>
                (new ProductsList<IProduct<IWeapon>>(new List<IProductCell<IProduct<IWeapon>>>()), null, new NullProductsListView<IProduct<IWeapon>>()); 
            }
            catch { errors++; }
            
            try 
            { 
                var weaponProductsList = new WeaponProductsList<Test>
                (new ProductsList<IProduct<IWeapon>>(new List<IProductCell<IProduct<IWeapon>>>()), new NullWeaponProductProductsFactory(), null); 
            }
            catch { errors++; }
            
            Assert.That(errors == 3);
        }
    }
}