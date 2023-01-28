namespace SwampAttack.Model.Rewards
{
    public interface IRewardRandomizer
    {
        IReward Randomize(IReward reward);
    }
}