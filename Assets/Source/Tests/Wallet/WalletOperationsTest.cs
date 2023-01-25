using NUnit.Framework;
using SwampAttack.Model.Wallet;
using SwampAttack.Tests.NullComponents;

namespace SwampAttack.Tests.Wallet
{
    public class WalletOperationsTest
    {
        private IWallet _wallet;
        
        [SetUp]
        public void Setup()
        {
            _wallet = new Wallet<ITestMoney>(new NullWalletView());
            _wallet.Take(_wallet.Money);
        }
        
        [Test]
        public void CantPutInvalidNumber()
        {
            try { _wallet.Put(-1); }
            catch { Assert.Pass(); }
        }

        [Test]
        public void IsPuttingValid()
        {
            _wallet.Put(5);
            if (_wallet.Money == 5)
                Assert.Pass();
        }

        [Test]
        public void CantTakeInvalidNumber()
        {
            var errors = 0;
            _wallet.Put(5);

            try { _wallet.Take(-1); }
            catch { errors++; }
            
            try { _wallet.Take(6); }
            catch { errors++; }
            
            if (errors == 2)
                Assert.Pass();
        }

        [Test]
        public void IsTakingValid()
        {
            _wallet.Put(5);
            _wallet.Take(3);
            
            if (_wallet.Money == 2)
                Assert.Pass();
        }
    }
}