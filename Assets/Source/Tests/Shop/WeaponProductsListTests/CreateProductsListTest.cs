using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;
using SwampAttack.NullComponents;

namespace SwampAttack.Shop.WeaponProductsListTests
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