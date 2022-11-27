using SwampAttack.Runtime.View.Wallet;

namespace SwampAttack.Tests.NullComponents.Wallet
{
    public class NullWalletView : IWalletView
    {
        public void Visualize(int money) { }
    }
}