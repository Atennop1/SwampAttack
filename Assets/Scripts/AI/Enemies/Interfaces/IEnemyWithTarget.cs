namespace SwampAttack.AI.Enemies.Interfaces
{
    public interface IEnemyWithTarget : IEnemy
    {
        IEnemyTargetData TargetData { get; }
    }
}