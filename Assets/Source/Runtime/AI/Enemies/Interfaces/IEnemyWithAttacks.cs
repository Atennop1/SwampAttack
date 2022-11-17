using System.Collections.Generic;

namespace SwampAttack.Runtime.AI.Enemies.Interfaces
{
    public interface IEnemyWithAttacks : IEnemy
    {
        IEnumerable<IEnemyAttack> Attacks { get; }
    }
}