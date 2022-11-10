using System;
using SwampAttack.AI.Enemies.Interfaces;
using SwampAttack.Root.SystemUpdate;
using UnityEngine;

namespace SwampAttack.AI.Enemies.Minotaur.Attacks
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

            if (cooldown < 0)
                throw new ArgumentException("Cooldown can't be negative number");
            
            _cooldown = cooldown;
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