using System;
using SwampAttack.Tools;

namespace SwampAttack.Model.Rewards
{
    public class NullRewardRandomizer : IRewardRandomizer
    {
        private readonly IRandomizer _randomizer;

        public NullRewardRandomizer(IRandomizer randomizer)
            => _randomizer = randomizer ?? throw new ArgumentNullException(nameof(randomizer));

        public IReward Randomize(IReward reward)
            => _randomizer.TryLuck() ? reward : new NullReward();
    }
}