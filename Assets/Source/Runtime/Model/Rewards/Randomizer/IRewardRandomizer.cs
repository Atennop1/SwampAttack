namespace SwampAttack.Model.Rewards
{
    public interface IRewardRandomizer
    {
        IReward NullOrDefault(IReward reward);
    }
}