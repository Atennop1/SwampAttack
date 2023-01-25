using UnityEngine;

namespace SwampAttack.Model.AI.Enemies
{
    public interface IEnemyTargetData
    {
        Transform Target { get; }
        float AttackRadius { get; }
    }
}