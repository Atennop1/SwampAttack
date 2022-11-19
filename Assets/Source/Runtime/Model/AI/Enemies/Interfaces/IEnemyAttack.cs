namespace SwampAttack.Runtime.Model.AI.Enemies.Interfaces
{
    public interface IEnemyAttack
    {
        bool CanUse { get; }
        void Use();
    }
}