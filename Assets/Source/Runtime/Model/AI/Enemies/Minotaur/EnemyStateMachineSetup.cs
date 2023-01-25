using System;
using SwampAttack.View.Enemies;
using UnityEngine;

namespace SwampAttack.Model.AI.Enemies
{
    public sealed class EnemyStateMachineSetup : IEnemyStateMachineSetup
    {
        private readonly IEnemyWithTarget _enemyWithTarget;
        private readonly IEnemyWithAttacks _enemyWithAttacks;
        private readonly IEnemyTransformView _enemyTransformView;
        
        public EnemyStateMachineSetup(IEnemyWithTarget enemyWithTarget, IEnemyWithAttacks enemyWithAttacks, IEnemyTransformView enemyTransformView)
        {
            _enemyWithTarget = enemyWithTarget ?? throw new ArgumentException("EnemyWithTarget can't be null");
            _enemyWithAttacks = enemyWithAttacks ?? throw new ArgumentException("EnemyWithAttacks can't be null");
            _enemyTransformView = enemyTransformView ?? throw new ArgumentException("EnemyView can't be null");
        }
        
        public Model.AI.StateMachine.StateMachine BuildStateMachine()
        {
            var stateMachine = new Model.AI.StateMachine.StateMachine();
            var playerTooFarState = new PlayerTooFarState(_enemyWithTarget, _enemyTransformView);
            var attackState = new AttackState(_enemyWithAttacks);
            var victoryState = new VictoryState(_enemyTransformView);
            
            stateMachine.AddTransition(playerTooFarState, attackState, PlayerToNear);
            stateMachine.AddTransition(attackState, playerTooFarState, PlayerTooFar);
            
            stateMachine.AddTransition(attackState, victoryState, PlayerIsDead);
            stateMachine.AddTransition(playerTooFarState, victoryState, PlayerIsDead);
            
            stateMachine.AddAnyTransition(new DeathState(), () => _enemyWithTarget.Health.IsDead);
            stateMachine.SwitchState(playerTooFarState);
            return stateMachine;
        }

        private bool PlayerToNear() 
            => _enemyWithTarget.TargetData.Target != null &&
               Vector2.Distance(_enemyTransformView.Transform.position, _enemyWithTarget.TargetData.Target.position) <= 
               _enemyWithTarget.TargetData.AttackRadius;
        
        private bool PlayerTooFar() 
            => _enemyWithTarget.TargetData.Target != null &&
               Vector2.Distance(_enemyTransformView.Transform.position, _enemyWithTarget.TargetData.Target.position) > 
               _enemyWithTarget.TargetData.AttackRadius;
        
        private bool PlayerIsDead() 
            => _enemyWithTarget.TargetData.Target == null;
    }
}