namespace SwampAttack.AI.Enemies.Interfaces
{
    public interface IEnemyAttack
    {
        bool CanUse { get; }
        void Use();
    }
}