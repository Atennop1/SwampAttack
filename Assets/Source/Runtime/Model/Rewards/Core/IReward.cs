namespace SwampAttack.Model.Rewards
{
    public interface IReward
    {
        RewardData Data { get; }
        bool IsApplied { get; }
        void Apply();
    }
}