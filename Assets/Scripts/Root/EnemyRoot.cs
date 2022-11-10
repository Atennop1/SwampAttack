using SwampAttack.AI.Enemies.Interfaces;
using SwampAttack.AI.Enemies.Minotaur;
using SwampAttack.AI.Enemies.Movement;
using SwampAttack.Attacks;
using SwampAttack.HealthSystem;
using SwampAttack.Root.Interfaces;
using UnityEngine;
using Update = SwampAttack.Root.SystemUpdate;

namespace SwampAttack.Root
{
    public sealed class EnemyRoot : CompositeRoot
    {
        [SerializeField] private HealthTransformView _healthTransformView;
        [SerializeField] private Transform _player;
        
        [Space]
        [SerializeField] private IEnemyTransformView _enemyTransformView;
        [SerializeField] private AttackTransformView _attackTransformView;
        [SerializeField] private Rigidbody2D _rigidbody;

        private Update.ISystemUpdate _systemUpdate = new Update.SystemUpdate();
        
        public override void Compose()
        {
            _systemUpdate = new SystemUpdate.SystemUpdate();

            IHealth health = new Health(3);
            _healthTransformView.Init(health);
            _attackTransformView.Init(new Attack(1));
            
            var enemy = new MinotaurEnemy(health, new DefaultEnemyMovement(_rigidbody, 10),
                new MinotaurTargetData(_player, 1.7f, 0.05f));
            
            enemy.Init(new StateMachineSetup(enemy, enemy, _enemyTransformView));
            _systemUpdate.Add(enemy);
        }

        private void Update() => _systemUpdate.UpdateAll();
    }
}