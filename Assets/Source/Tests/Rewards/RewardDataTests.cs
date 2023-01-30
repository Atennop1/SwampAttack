using NUnit.Framework;
using SwampAttack.Model.Rewards;
using UnityEngine;

namespace SwampAttack.Tests.Rewards
{
    public class RewardDataTests
    {
        [Test]
        public void CantCreateInvalidClient()
        {
            var errors = 0;

            try { var rewardData = new RewardData(null, 1); }
            catch { errors++; }

            try
            {
                var nullSprite = Sprite.Create(Texture2D.blackTexture, Rect.zero, Vector2.down);
                var rewardData = new RewardData(nullSprite, -1);
            }
            catch { errors++; }

            Assert.That(errors == 2);
        }
    }
}