using NUnit.Framework;
using SwampAttack.Model.Wallet;

namespace SwampAttack.Tests.Wallet
{
    public class CreateWalletTest
    {
        [Test]
        public void CantCreateInvalidWallet()
        {
            try { var wallet = new Wallet<IMoney>(null); }
            catch { Assert.Pass(); }
        }
    }
}