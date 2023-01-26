using NUnit.Framework;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;
using SwampAttack.Tests.NullComponents;

namespace SwampAttack.Tests.Shop.Product
{
    public class CreateProductTest
    {
        [Test]
        public void CantCreateInvalidProduct()
        {
            var errors = 0;
            
            try { var product = new Product<IWeapon>(null, new NullProductData()); }
            catch { errors++; }
            
            try { var product = new Product<IWeapon>(new Weapon(new NullBulletsFactory(), new NullWeaponBulletsView(), 1), null); }
            catch { errors++; }
            
            Assert.That(errors == 2);
        }
    }
}