using System.Collections.Generic;

namespace SwampAttack.Runtime.Model.AI.Enemies.Interfaces
{
    public interface IEnemyWithAttacks : IEnemy
    {
        IEnumerable<IEnemyAttack> Attacks { get; }
    }
}