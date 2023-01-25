namespace SwampAttack.Model.AI.Enemies
{
    public interface IEnemyAttack
    {
        bool CanUse { get; }
        void Use();
    }
}