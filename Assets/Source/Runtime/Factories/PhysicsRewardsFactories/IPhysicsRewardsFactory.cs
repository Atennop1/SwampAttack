using SwampAttack.View.Reward;
using UnityEngine;

namespace SwampAttack.Factories
{
    public interface IPhysicsRewardsFactory
    {
        IPhysicsReward Create(Vector3 position);
    }
}