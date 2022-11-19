using System.Collections.Generic;

namespace SwampAttack.Runtime.Model.AI.Enemies.Interfaces
{
    public interface IStateMachineSetup
    {
        Model.AI.StateMachine.StateMachine BuildStateMachine();
        IEnumerable<IEnemyAttack> BuildEnemyAttacks();
    }
}