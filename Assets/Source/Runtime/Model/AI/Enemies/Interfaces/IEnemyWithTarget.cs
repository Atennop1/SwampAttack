namespace SwampAttack.Runtime.Model.AI.Enemies.Interfaces
{
    public interface IEnemyWithTarget : IEnemy
    {
        IEnemyTargetData TargetData { get; }
    }
}