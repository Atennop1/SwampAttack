using SwampAttack.Runtime.Model.AI.Enemies.Movement;
using SwampAttack.Runtime.Model.HealthSystem;

namespace SwampAttack.Runtime.Model.AI.Enemies.Interfaces
{
    public interface IEnemy
    {
        IHealth Health { get; }
        Model.AI.StateMachine.StateMachine StateMachine { get; }
        IEnemyMovement Movement { get; }
    }
}