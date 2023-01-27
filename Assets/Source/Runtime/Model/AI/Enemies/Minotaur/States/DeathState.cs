using System;
using SwampAttack.Factories;
using SwampAttack.Model.AI.StateMachine;
using SwampAttack.View.Enemies;
using UnityEngine;

namespace SwampAttack.Model.AI.Enemies
{
    public sealed class DeathState : IState
    {
        private readonly IPhysicsRewardsFactory _rewardsFactory;
        private readonly IEnemyTransformView _enemyTransformView;

        public DeathState(IEnemyTransformView enemyTransformView, IPhysicsRewardsFactory rewardsFactory)
        {
            _enemyTransformView = enemyTransformView ?? throw new ArgumentNullException(nameof(enemyTransformView));
            _rewardsFactory = rewardsFactory ?? throw new ArgumentNullException(nameof(rewardsFactory));
        }

        public void OnEnter()
        {
            Debug.Log("death");
            _rewardsFactory.Create(_enemyTransformView.Transform.position);
        }

        public void Tick() { }
        public void OnExit() { }
    }
}