using System;
using SwampAttack.Runtime.AI.Enemies.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SwampAttack.Runtime.AI.Enemies.Minotaur
{
    public sealed class MinotaurTargetData : IEnemyTargetData
    {
        public Transform Target { get; }
        public float AttackRadius { get; }
        
        public MinotaurTargetData(Transform target, float attackRadius, float spread)
        {
            Target = target;

            if (attackRadius < 0)
                throw new ArgumentException("AttackRadius can't be negative number");

            if (spread < 0)
                throw new ArgumentException("RadiusSpread can't be negative number");

            if (spread >= attackRadius)
                throw new ArgumentException("RadiusSpread can't be greater or equals AttackRadius");
            
            AttackRadius = attackRadius + Random.Range(-spread, spread);
        }
    }
}