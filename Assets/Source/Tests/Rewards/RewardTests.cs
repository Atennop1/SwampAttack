using System;
using NUnit.Framework;
using SwampAttack.Model.Rewards;
using SwampAttack.Model.Wallet;
using SwampAttack.Tests.NullComponents;
using UnityEngine;

namespace SwampAttack.Tests.Rewards
{
    public class RewardTests
    {
        [Test]
        public void CantCreateInvalidReward()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var reward = new Reward(null, new RewardData());
            });
        }

        [Test]
        public void IsRewardWorkingCorrect()
        {
            var wallet = new Wallet<ITestMoney>(new NullWalletView());
            var moneyCountBefore = wallet.Money;
            var nullSprite = Sprite.Create(Texture2D.blackTexture, Rect.zero, Vector2.down);

            var reward = new Reward(wallet, new RewardData(nullSprite, 10));
            reward.Apply();
            
            Assert.That(reward.IsApplied && moneyCountBefore + 10 == wallet.Money);
        }
    }
}