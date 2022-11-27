using NUnit.Framework;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Tests.NullComponents.Inventory;
using SwampAttack.Tests.NullComponents.Products;

namespace SwampAttack.Tests.Shop.Product
{
    public class CreateProductTest
    {
        [Test]
        public void CantCreateInvalidProduct()
        {
            var errors = 0;
            
            try { var product = new WeaponProduct(null, new NullProductData(1)); }
            catch { errors++; }
            
            try { var product = new WeaponProduct(new Weapon(new NullBulletsFactory(), new NullWeaponBulletsView(), 1), null); }
            catch { errors++; }
            
            Assert.That(errors == 2);
        }
    }
}