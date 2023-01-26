using System;

namespace SwampAttack.Model.Rewards
{
    public class RewardRandomizer : IRewardRandomizer
    {
        private readonly IChance _chance;

        public RewardRandomizer(IChance chance)
            => _chance = chance ?? throw new ArgumentNullException(nameof(chance));

        public IReward NullOrDefault(IReward reward)
            => _chance.TryLuck() ? reward : new NullReward();
    }
}