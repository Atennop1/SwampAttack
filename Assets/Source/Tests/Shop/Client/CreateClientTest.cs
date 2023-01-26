using NUnit.Framework;
using SwampAttack.Model.InventorySystem;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;
using SwampAttack.Tests.NullComponents;

namespace SwampAttack.Tests.Shop.Client
{
    public class CreateClientTest
    {
        [Test]
        public void CantCreateInvalidClient()
        {
            var errors = 0;

            try { var client = new Client<IWeapon>(new NullWallet(1), null); }
            catch { errors++; }
            
            try { var client = new Client<IWeapon>(null,new Inventory<IWeapon>(1)); }
            catch { errors++; }

            Assert.That(errors == 2);
        }
    }
}