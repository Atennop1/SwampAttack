using UnityEngine;

namespace SwampAttack.Runtime.AI.Enemies.Interfaces
{
    public interface IEnemyTargetData
    {
        Transform Target { get; }
        float AttackRadius { get; }
    }
}