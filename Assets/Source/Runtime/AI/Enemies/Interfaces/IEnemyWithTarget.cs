namespace SwampAttack.Runtime.AI.Enemies.Interfaces
{
    public interface IEnemyWithTarget : IEnemy
    {
        IEnemyTargetData TargetData { get; }
    }
}