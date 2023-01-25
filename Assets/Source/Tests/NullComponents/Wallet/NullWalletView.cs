using SwampAttack.View.Wallet;

namespace SwampAttack.Tests.NullComponents
{
    public class NullWalletView : IWalletView
    {
        public void Visualize(int money) { }
    }
}