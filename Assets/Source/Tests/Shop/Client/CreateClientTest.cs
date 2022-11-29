using NUnit.Framework;
using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Shop.Clients;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Tests.NullComponents.Products;
using SwampAttack.Tests.NullComponents.Wallet;

namespace SwampAttack.Tests.Shop.Client
{
    public class CreateClientTest
    {
        [Test]
        public void CantCreateInvalidClient()
        {
            var errors = 0;

            try { var client = new Client<IWeapon>(new NullProductsList<IWeapon>(), new NullWallet(1), null); }
            catch { errors++; }
            
            try { var client = new Client<IWeapon>(new NullProductsList<IWeapon>(), null,new Inventory<IWeapon>(1)); }
            catch { errors++; }
            
            try { var client = new Client<IWeapon>(null, new NullWallet(1),new Inventory<IWeapon>(1)); }
            catch { errors++; }

            Assert.That(errors == 3);
        }
    }
}