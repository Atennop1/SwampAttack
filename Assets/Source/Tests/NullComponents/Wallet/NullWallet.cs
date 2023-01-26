using SwampAttack.Model.Wallet;

namespace SwampAttack.Tests.NullComponents
{
    public class NullWallet : IWallet
    {
        public int Money { get; }
        
        public NullWallet(int money)
        {
            Money = money;
        }
        
        public void Put(int count) { }
        public void Take(int count) { }
        
        public bool CanTake(int count) 
            => false;
    }
}