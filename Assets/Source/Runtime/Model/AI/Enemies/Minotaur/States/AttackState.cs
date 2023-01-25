using System;
using System.Linq;
using SwampAttack.Model.AI.StateMachine;

namespace SwampAttack.Model.AI.Enemies
{
    public sealed class AttackState : IState
    {
        private readonly IEnemyWithAttacks _enemyWithAttacks;
        private readonly IEnemyAttack _enemyAttack;

        public AttackState(IEnemyWithAttacks enemyWithAttacks)
        {
            _enemyWithAttacks = enemyWithAttacks ?? throw new ArgumentException("_enemyWithAttacks can't be null");
            try { _enemyAttack = enemyWithAttacks.Attacks.Where(x => x != null).ToList()[0]; }
            catch { throw new ArgumentException("Enemy hasn't attacks of type IEnemyAttack"); }
        }

        public void Tick()
        {
            if (_enemyAttack.CanUse)
                _enemyAttack.Use();
        }

        public void OnEnter() 
            => _enemyWithAttacks.Movement.StopMovement();
        
        public void OnExit() { }
    }
}