using UnityEngine;

namespace SwampAttack.Runtime.Model.AI.Enemies.Interfaces
{
    public interface IEnemyTargetData
    {
        Transform Target { get; }
        float AttackRadius { get; }
    }
}