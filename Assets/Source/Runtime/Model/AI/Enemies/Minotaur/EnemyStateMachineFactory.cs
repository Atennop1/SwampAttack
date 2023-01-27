using System;
using SwampAttack.Factories;
using SwampAttack.View.Enemies;
using UnityEngine;

namespace SwampAttack.Model.AI.Enemies
{
    public sealed class EnemyStateMachineFactory : IEnemyStateMachineFactory
    {
        private readonly IEnemyWithTarget _enemyWithTarget;
        private readonly IEnemyWithAttacks _enemyWithAttacks;
        private readonly IEnemyTransformView _enemyTransformView;
        private readonly IPhysicsRewardsFactory _physicsRewardsFactory;

        public EnemyStateMachineFactory(IEnemy enemy, IEnemyTransformView enemyTransformView, IPhysicsRewardsFactory physicsRewardsFactory)
        {
            _enemyWithTarget = enemy as IEnemyWithTarget ?? throw new ArgumentException("EnemyWithTarget can't be null");
            _enemyWithAttacks = enemy as IEnemyWithAttacks ?? throw new ArgumentException("EnemyWithAttacks can't be null");
            _enemyTransformView = enemyTransformView ?? throw new ArgumentException("EnemyView can't be null");
            _physicsRewardsFactory = physicsRewardsFactory ?? throw new ArgumentNullException(nameof(physicsRewardsFactory));
        }

        public Model.AI.StateMachine.StateMachine Create()
        {
            var stateMachine = new Model.AI.StateMachine.StateMachine();
            var playerTooFarState = new PlayerTooFarState(_enemyWithTarget, _enemyTransformView);
            var attackState = new AttackState(_enemyWithAttacks);
            var victoryState = new VictoryState(_enemyTransformView);
            
            stateMachine.AddTransition(playerTooFarState, attackState, PlayerToNear);
            stateMachine.AddTransition(attackState, playerTooFarState, PlayerTooFar);
            
            stateMachine.AddTransition(attackState, victoryState, PlayerIsDead);
            stateMachine.AddTransition(playerTooFarState, victoryState, PlayerIsDead);
            
            stateMachine.AddAnyTransition(new DeathState(_enemyTransformView, _physicsRewardsFactory), () => _enemyWithTarget.Health.IsDead);
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