using System;
using UnityEngine;

namespace SwampAttack.Model.Rewards
{
    public readonly struct RewardData
    {
        public readonly int CoinsCount;
        public readonly Sprite Sprite;

        public RewardData(Sprite sprite, int coinsCount)
        {
            Sprite = sprite ?? throw new ArgumentNullException(nameof(sprite));
            CoinsCount = coinsCount;
        }
    }
}