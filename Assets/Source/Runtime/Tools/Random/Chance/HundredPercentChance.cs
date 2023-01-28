namespace SwampAttack.Model.Rewards
{
    public class HundredPercentChance : IChance
    {
        public bool TryLuck()
            => true;
    }
}