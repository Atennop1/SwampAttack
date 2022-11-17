using SwampAttack.Runtime.AI.Enemies.Movement;
using SwampAttack.Runtime.HealthSystem;

namespace SwampAttack.Runtime.AI.Enemies.Interfaces
{
    public interface IEnemy
    {
        IHealth Health { get; }
        StateMachine.StateMachine StateMachine { get; }
        IEnemyMovement Movement { get; }
    }
}