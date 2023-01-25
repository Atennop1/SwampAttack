namespace SwampAttack.Model.AI.Enemies
{
    public interface IEnemyWithTarget : IEnemy
    {
        IEnemyTargetData TargetData { get; }
    }
}