using System.Collections.Generic;

namespace SwampAttack.Runtime.Model.AI.Enemies.Interfaces
{
    public interface IEnemyAttacksSetup
    {
        IEnumerable<IEnemyAttack> BuildEnemyAttacks();
    }
}