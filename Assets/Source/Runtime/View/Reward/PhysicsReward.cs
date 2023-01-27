using System;
using SwampAttack.Model.Rewards;
using UnityEngine;

namespace SwampAttack.View.Reward
{
    public class PhysicsReward : MonoBehaviour, IPhysicsReward
    {
        private IReward _reward;

        public void Init(IReward reward)
            => _reward = reward ?? throw new ArgumentNullException(nameof(reward));
    }
}