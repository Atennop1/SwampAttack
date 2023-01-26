using System;
using SwampAttack.View.Reward;

namespace SwampAttack.Model.Rewards
{
    public sealed class Reward : IReward
    {
        public RewardData Data { get; }
        public bool IsApplied { get; private set; }

        private readonly IRewardView _rewardView;
        
        public Reward(IRewardView rewardView, RewardData data)
        {
            _rewardView = rewardView ?? throw new ArgumentNullException(nameof(rewardView));
            Data = data;
        }

        public void Apply()
        {
            if (IsApplied)
                throw new InvalidOperationException("Can't apply applied reward");
            
            _rewardView.DisplayApplied(Data);
            IsApplied = true;
        }
    }
}