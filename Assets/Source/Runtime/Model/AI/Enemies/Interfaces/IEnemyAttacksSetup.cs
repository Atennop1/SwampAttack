using System.Collections.Generic;

namespace SwampAttack.Model.AI.Enemies
{
    public interface IEnemyAttacksSetup
    {
        IEnumerable<IEnemyAttack> BuildEnemyAttacks();
    }
}