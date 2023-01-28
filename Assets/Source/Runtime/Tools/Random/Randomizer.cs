using System;
using SwampAttack.Model.Rewards;

namespace SwampAttack.Tools
{
    public class Randomizer : IRandomizer
    {
        private readonly IChance _chance;

        public Randomizer(IChance chance)
            => _chance = chance ?? throw new ArgumentNullException(nameof(chance));

        public bool TryLuck()
            => _chance.TryLuck();
    }
}