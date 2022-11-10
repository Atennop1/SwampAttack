using SwampAttack.AI.Enemies.Movement;
using SwampAttack.HealthSystem;
using SM = SwampAttack.AI.StateMachine;

namespace SwampAttack.AI.Enemies.Interfaces
{
    public interface IEnemy
    {
        IHealth Health { get; }
        SM.StateMachine StateMachine { get; }
        IEnemyMovement Movement { get; }
    }
}