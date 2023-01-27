using System;
using SwampAttack.Tools;
using UnityEngine;

namespace SwampAttack.Model.Rewards
{
    public readonly struct RewardData
    {
        public readonly int CoinsCount;
        public readonly Sprite Icon;

        public RewardData(Sprite icon, int coinsCount)
        {
            Icon = icon ?? throw new ArgumentNullException(nameof(icon));
            CoinsCount = coinsCount.TryThrowIfLessOrEqualsZero();
        }
    }
}