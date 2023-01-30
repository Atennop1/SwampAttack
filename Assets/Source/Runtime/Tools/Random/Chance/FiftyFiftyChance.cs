using UnityEngine;

namespace SwampAttack.Tools
{
    public class FiftyFiftyChance : IChance
    {
        public bool TryLuck()
            => Random.Range(0, 2) == 1;
    }
}