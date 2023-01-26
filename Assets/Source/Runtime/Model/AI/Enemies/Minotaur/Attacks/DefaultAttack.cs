using System;
using SwampAttack.Root;
using SwampAttack.Tools;
using SwampAttack.View.Enemies;
using UnityEngine;

namespace SwampAttack.Model.AI.Enemies
{
    public sealed class DefaultAttack : IEnemyAttack, IUpdatable
    {
        public bool CanUse { get; private set; }
        
        private readonly float _cooldown;
        private readonly IEnemyTransformView _enemyTransformView;
        private float _remainingTime;

        public DefaultAttack(IEnemyTransformView enemyTransformView, float cooldown)
        {
            _enemyTransformView = enemyTransformView ?? throw new ArgumentException("EnemyView can't be null");
            _cooldown = cooldown.TryThrowIfLessThanZero();
        }

        public void Use()
        {
            if (!CanUse)
                return;
            
            _enemyTransformView.PlayAnimation("Attack");
            CanUse = false;
        }

        public void Update()
        {
            if (CanUse)
                return;
            
            if (_remainingTime > 0)
                _remainingTime -= Time.deltaTime;

            if (_remainingTime > 0) return;
            
            _remainingTime = _cooldown;
            CanUse = true;
        }
    }
}