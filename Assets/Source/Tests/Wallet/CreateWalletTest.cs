using NUnit.Framework;
using SwampAttack.Runtime.Model.Wallet;
using SwampAttack.Runtime.Tools.SaveSystem;
using SwampAttack.Tests.NullComponents.Wallet;

namespace SwampAttack.Tests.Wallet
{
    public class CreateWalletTest
    {
        [Test]
        public void CantCreateInvalidWallet()
        {
            var errors = 0;

            try { var wallet = new Wallet<IMoney>(null, new NullWalletView()); }
            catch { errors++; }
            
            try { var wallet = new Wallet<IMoney>(new JSONStorage(), null); }
            catch { errors++; }
            
            if (errors == 2)
                Assert.Pass();
        }
    }
}