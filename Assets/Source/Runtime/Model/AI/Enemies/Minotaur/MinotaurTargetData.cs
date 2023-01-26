using System;
using SwampAttack.Tools;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SwampAttack.Model.AI.Enemies
{
    public sealed class MinotaurTargetData : IEnemyTargetData
    {
        public Transform Target { get; }
        public float AttackRadius { get; }
        
        public MinotaurTargetData(Transform target, float attackRadius, float spread)
        {
            attackRadius.TryThrowIfLessThanZero(); 
            spread.TryThrowIfLessThanZero();

            if (spread >= attackRadius)
                throw new ArgumentException("RadiusSpread can't be greater or equals AttackRadius");
            
            AttackRadius = attackRadius + Random.Range(-spread, spread);
            Target = target ?? throw new ArgumentNullException(nameof(target));
        }
    }
}