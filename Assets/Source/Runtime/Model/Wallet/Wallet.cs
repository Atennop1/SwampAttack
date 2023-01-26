using System;
using SwampAttack.Tools;
using SwampAttack.View.Wallet;

namespace SwampAttack.Model.Wallet
{
    public class Wallet<TCurrency> : IWallet
    {
        public int Money { get; private set; }
        private readonly StorageWithNames<IWallet, TCurrency> _storage;
        private readonly IWalletView _view;
        
        public Wallet(IWalletView view)
        {
            _view = view ?? throw new ArgumentException("View can't be null"); ;
            _storage = new StorageWithNames<IWallet, TCurrency>();
            
            Money = _storage.Exist() ? _storage.Load<int>() : 0;
            VisualizeAndSave();
        }
        
        public void Put(int count)
        {
            Money += count.TryThrowIfLessOrEqualsZero();
            VisualizeAndSave();
        }

        public void Take(int count)
        {
            if (count.TryThrowIfLessThanZero() > Money)
                throw new ArgumentException($"Can't take {count} money from wallet where only {Money} money");

            Money -= count;
            VisualizeAndSave();
        }

        public bool CanTake(int count) 
            => count.TryThrowIfLessOrEqualsZero() < Money;

        private void VisualizeAndSave()
        {
            _view.Visualize(Money);
            _storage.Save(Money);
        }
    }
}