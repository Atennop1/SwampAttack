using System;
using SwampAttack.Runtime.Model.AI.Enemies.Interfaces;
using SwampAttack.Runtime.Model.AI.StateMachine;
using SwampAttack.Runtime.View.Enemies;

namespace SwampAttack.Runtime.Model.AI.Enemies.Minotaur.States
{
    public sealed class PlayerTooFarState : IState
    {
        private readonly IEnemyWithTarget _enemy;
        private readonly IEnemyTransformView _enemyTransformView;

        public PlayerTooFarState(IEnemyWithTarget enemy, IEnemyTransformView enemyTransformView)
        {
            _enemy = enemy ?? throw new ArgumentException("Enemy can't be null");
            _enemyTransformView = enemyTransformView ?? throw new ArgumentException("EnemyView can't be null");
        }

        public void OnEnter()
        {
            _enemyTransformView.PlayAnimation("Walk");
        }

        public void Tick()
        {
            _enemy.Movement.Move(_enemy.TargetData.Target);
        }
        
        public void OnExit() { }
    }
}