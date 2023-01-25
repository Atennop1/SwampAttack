using System;
using System.Collections.Generic;
using SwampAttack.Runtime.Model.AI.Enemies.Interfaces;
using SwampAttack.Runtime.Model.AI.Enemies.Movement;
using SwampAttack.Runtime.Model.HealthSystem;
using SwampAttack.Runtime.Root.SystemUpdates;
using SwampAttack.Runtime.View.Enemies;

namespace SwampAttack.Runtime.Model.AI.Enemies.Minotaur
{
    public sealed class MinotaurEnemy : IEnemyWithTarget, IEnemyWithAttacks, IUpdatable
    {
        public IHealth Health { get; }
        public Model.AI.StateMachine.StateMachine StateMachine { get; private set; }
        public IEnemyMovement Movement { get; }
        
        public IEnemyTargetData TargetData { get; }
        public IEnumerable<IEnemyAttack> Attacks { get; private set; }
        private IEnemyTransformView _transformView;

        public MinotaurEnemy(IHealth health, IEnemyMovement movement, IEnemyTargetData targetData)
        {
            Health = health ?? throw new ArgumentException("Health can't be null");
            TargetData = targetData ?? throw new ArgumentException("TargetData can't be null");
            Movement = movement ?? throw new ArgumentException("Movement can't be null");
        }

        public void Init(IEnemyStateMachineSetup stateMachineSetup, IEnemyAttacksSetup attacksSetup)
        {
            if (stateMachineSetup == null)
                throw new ArgumentException("StateMachineSetup can't be null");
            
            Attacks = attacksSetup.BuildEnemyAttacks();
            StateMachine = stateMachineSetup.BuildStateMachine();
        }

        public void Update() 
            => StateMachine.Tick();
    }
}