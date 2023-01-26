using UnityEngine;

namespace SwampAttack.Model.Rewards
{
    public class FiftyFiftyChance : IChance
    {
        public bool TryLuck()
            => Random.Range(0, 2) == 1;
    }
}