using System.Collections.Generic;

namespace SwampAttack.Runtime.AI.Enemies.Interfaces
{
    public interface IStateMachineSetup
    {
        StateMachine.StateMachine BuildStateMachine();
        IEnumerable<IEnemyAttack> BuildEnemyAttacks();
    }
}