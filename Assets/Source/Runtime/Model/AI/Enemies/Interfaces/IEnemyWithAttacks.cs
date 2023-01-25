using System.Collections.Generic;

namespace SwampAttack.Model.AI.Enemies
{
    public interface IEnemyWithAttacks : IEnemy
    {
        IEnumerable<IEnemyAttack> Attacks { get; }
    }
}