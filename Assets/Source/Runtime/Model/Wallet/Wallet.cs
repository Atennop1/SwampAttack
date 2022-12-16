using System;
using SwampAttack.Runtime.Tools.SaveSystem;
using SwampAttack.Runtime.View.Wallet;

namespace SwampAttack.Runtime.Model.Wallet
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
            if (count <= 0)
                throw new ArgumentException("Can't put negative numbers in wallet");

            Money += count;
            VisualizeAndSave();
        }

        public void Take(int count)
        {
            if (count > Money)
                throw new ArgumentException($"Can't take {count} money from wallet where only {Money} money");

            if (count < 0)
                throw new ArgumentException("Can't take negative number from wallet");

            Money -= count;
            VisualizeAndSave();
        }

        public bool CanTake(int count) => count < Money && count > 0;

        private void VisualizeAndSave()
        {
            _view.Visualize(Money);
            _storage.Save(Money);
        }
    }
}