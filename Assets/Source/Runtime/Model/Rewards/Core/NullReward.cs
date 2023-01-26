namespace SwampAttack.Model.Rewards
{
    public class NullReward : IReward
    {
        public RewardData Data { get; }
        public bool IsApplied { get; }
        public void Apply() { }
    }
}