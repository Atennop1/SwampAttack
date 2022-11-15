using System.Threading.Tasks;
using SwampAttack.AI.Enemies.Interfaces;
using SwampAttack.AI.Enemies.Minotaur;
using SwampAttack.AI.Enemies.Movement;
using SwampAttack.Attacks;
using SwampAttack.HealthSystem;
using SwampAttack.Root.Interfaces;
using SwampAttack.Root.SystemUpdates;
using UnityEngine;

namespace SwampAttack.Root
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