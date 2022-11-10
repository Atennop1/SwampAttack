using System.Collections.Generic;

namespace SwampAttack.AI.Enemies.Interfaces
{
    public interface IEnemyWithAttacks : IEnemy
    {
        IEnumerable<IEnemyAttack> Attacks { get; }
    }
}