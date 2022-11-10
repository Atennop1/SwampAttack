using System.Collections.Generic;
using SM = SwampAttack.AI.StateMachine;

namespace SwampAttack.AI.Enemies.Interfaces
{
    public interface IStateMachineSetup
    {
        SM.StateMachine BuildStateMachine();
        IEnumerable<IEnemyAttack> BuildEnemyAttacks();
    }
}