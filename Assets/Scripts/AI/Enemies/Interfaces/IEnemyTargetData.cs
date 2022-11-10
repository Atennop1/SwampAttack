using UnityEngine;

namespace SwampAttack.AI.Enemies.Interfaces
{
    public interface IEnemyTargetData
    {
        Transform Target { get; }
        float AttackRadius { get; }
    }
}