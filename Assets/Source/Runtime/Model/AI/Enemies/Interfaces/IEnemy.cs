using SwampAttack.Model.HealthSystem;

namespace SwampAttack.Model.AI.Enemies
{
    public interface IEnemy
    {
        IHealth Health { get; }
        Model.AI.StateMachine.StateMachine StateMachine { get; }
        IEnemyMovement Movement { get; }
    }
}