using System;
using SwampAttack.Model.Wallet;

namespace SwampAttack.Model.Rewards
{
    public sealed class Reward : IReward
    {
        public RewardData Data { get; }
        public bool IsApplied { get; private set; }

        private readonly IWallet _wallet;

        public Reward(IWallet wallet, RewardData data)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            Data = data;
        }

        public void Apply()
        {
            if (IsApplied)
                throw new InvalidOperationException("Can't apply applied reward");
            
            _wallet.Put(Data.CoinsCount);
            IsApplied = true;
        }
    }
}