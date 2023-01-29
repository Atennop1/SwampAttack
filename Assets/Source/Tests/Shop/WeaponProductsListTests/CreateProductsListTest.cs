using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SwampAttack.Model.InventorySystem;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;
using SwampAttack.Tests.NullComponents;

namespace SwampAttack.Tests.Shop.WeaponProductsListTests
{
    public class CreateProductsListTest
    {
        [Test]
        public void CantCreateInvalidProductsList()
        {
            var errors = 0;
            
            try { var weaponProductsList = new WeaponProductsList<Test>(null, new NullWeaponProductProductsFactory(), 
                new NullProductsListView<IInventorySlot<IProduct<IWeapon>>>()); }
            
            catch { errors++; }
            
            try 
            { 
                var weaponProductsList = new WeaponProductsList<Test>
                (new ProductsList<IInventorySlot<IProduct<IWeapon>>>(new List<IProductCell<IInventorySlot<IProduct<IWeapon>>>>()),
                    null, new NullProductsListView<IInventorySlot<IProduct<IWeapon>>>()); 
            }
            catch { errors++; }
            
            try 
            { 
                var weaponProductsList = new WeaponProductsList<Test>
                (new ProductsList<IInventorySlot<IProduct<IWeapon>>>(new List<IProductCell<IInventorySlot<IProduct<IWeapon>>>>()), 
                    new NullWeaponProductProductsFactory(), null); 
            }
            catch { errors++; }
            
            Assert.That(errors == 3);
        }
    }
}