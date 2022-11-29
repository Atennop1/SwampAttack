using NUnit.Framework;
using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Shop.Clients;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Tests.NullComponents.Wallet;

namespace SwampAttack.Tests.Shop.Client
{
    public class CreateClientTest
    {
        [Test]
        public void CantCreateInvalidClient()
        {
            var errors = 0;
            
            try { var client = new Runtime.Model.Shop.Clients.Client(null, new Inventory<IWeapon>(1)); }
            catch { errors++; }
            
            try { var client = new Runtime.Model.Shop.Clients.Client(new NullWallet(1), null); }
            catch { errors++; }
            
            if (errors == 2)
                Assert.Pass();
        }
    }
}