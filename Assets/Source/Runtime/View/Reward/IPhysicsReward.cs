using SwampAttack.Model.Input;
using SwampAttack.Model.Rewards;

namespace SwampAttack.View.Reward
{
    public interface IPhysicsReward : IRaycastHittable
    {
        void Init(IReward reward);
    }
}