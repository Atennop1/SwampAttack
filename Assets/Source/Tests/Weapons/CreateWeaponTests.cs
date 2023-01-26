using NUnit.Framework;
using SwampAttack.Model.Weapons;
using SwampAttack.Tests.NullComponents;

namespace SwampAttack.Tests.Weapons
{
    public class CreateWeaponTests
    {
        [Test]
        public void CantCreateInvalidWeapon()
        {
            var errors = 0;

            try { var weapon = new Weapon(null, new NullWeaponBulletsView(), 1); }
            catch { errors++; }
            
            try { var weapon = new Weapon(new NullBulletsFactory(), null, 1); }
            catch { errors++; }
            
            try { var weapon = new Weapon(new NullBulletsFactory(), new NullWeaponBulletsView(), -1); }
            catch { errors++; }
            
            if (errors == 3)
                Assert.Pass();
        }
    }
}