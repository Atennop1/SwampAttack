using SwampAttack.Runtime.HealthSystem;
using SwampAttack.Runtime.Model.AI.Enemies.Interfaces;
using SwampAttack.Runtime.Model.AI.Enemies.Minotaur;
using SwampAttack.Runtime.Model.AI.Enemies.Movement;
using SwampAttack.Runtime.Model.Attacks;
using SwampAttack.Runtime.Model.HealthSystem;
using SwampAttack.Runtime.Root.Interfaces;
using SwampAttack.Runtime.Root.SystemUpdates;
using SwampAttack.Runtime.View.Attacks;
using SwampAttack.Runtime.View.Enemies;
using SwampAttack.Runtime.View.Health;
using UnityEngine;

namespace SwampAttack.Runtime.Root
{
    public sealed class EnemyRoot : CompositeRoot
    {
        public IEnemy Enemy { get; private set; }
        
        [SerializeField] private HealthTransformView _healthTransformView;
        [SerializeField] private IEnemyTransformView _enemyTransformView;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private AttackTransformView _attackTransformView;

        private ISystemUpdate _systemUpdate = new SystemUpdate();
        private Transform _target;

        public void Init(Transform target)
        {
            _target = target;
        }
        
        public override void Compose()
        {
            _systemUpdate = new SystemUpdate();

            IHealth health = new Health(3);
            _healthTransformView.Init(health);
            _attackTransformView.Init(new Attack(1));
            
            var enemy = new MinotaurEnemy(health, new DefaultEnemyMovement(_rigidbody, 10),
                new MinotaurTargetData(_target, 1.7f, 0.05f));
            enemy.Init(new StateMachineSetup(enemy, enemy, _enemyTransformView));
            
            Enemy = enemy;
            _systemUpdate.Add(enemy);
        }

        private void Update() => _systemUpdate.UpdateAll();
    }
}