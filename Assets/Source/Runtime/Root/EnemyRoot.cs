using System;
using Sirenix.OdinInspector;
using SwampAttack.Factories;
using SwampAttack.Model.AI.Enemies;
using SwampAttack.Model.Attacks;
using SwampAttack.Model.HealthSystem;
using SwampAttack.View.Attacks;
using SwampAttack.View.Enemies;
using SwampAttack.View.Health;
using UnityEngine;

namespace SwampAttack.Root
{
    public sealed class EnemyRoot : SerializedMonoBehaviour
    {
        [SerializeField] private IHealthTransformView _healthTransformView;
        [SerializeField] private IEnemyTransformView _enemyTransformView;
        [SerializeField] private AttackTransformView _attackTransformView;
        [SerializeField] private Rigidbody2D _rigidbody;

        private ISystemUpdate _systemUpdate = new SystemUpdate();
        private IPhysicsRewardsFactory _physicsRewardsFactory;
        private Transform _target;

        public void Init(IPhysicsRewardsFactory rewardsFactory, Transform target)
        {
            _physicsRewardsFactory = rewardsFactory ?? throw new ArgumentNullException(nameof(rewardsFactory));
            _target = target ?? throw new ArgumentNullException(nameof(target));
        }

        public IEnemy Compose()
        {
            _systemUpdate = new SystemUpdate();

            IHealth health = new Health(3, new NullHealthView());
            _healthTransformView.Init(health);
            _attackTransformView.Init(new Attack(1));
            
            var enemy = new MinotaurEnemy(health, new DefaultEnemyMovement(_rigidbody, 10),
                new MinotaurTargetData(_target, 1.7f, 0.05f));

            var attacksSetup = new EnemyAttacksSetup(_enemyTransformView);
            enemy.Init(new EnemyStateMachineFactory(enemy, _enemyTransformView, _physicsRewardsFactory), attacksSetup);
            
            _systemUpdate.Add(enemy);
            _systemUpdate.Add(attacksSetup);

            return enemy;
        }

        private void Update() 
            => _systemUpdate.UpdateAll();
    }
}