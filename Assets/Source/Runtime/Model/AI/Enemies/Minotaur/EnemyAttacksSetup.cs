using System;
using System.Collections.Generic;
using SwampAttack.Runtime.Model.AI.Enemies.Interfaces;
using SwampAttack.Runtime.Model.AI.Enemies.Minotaur.Attacks;
using SwampAttack.Runtime.Root.SystemUpdates;
using SwampAttack.Runtime.View.Enemies;

namespace SwampAttack.Runtime.Model.AI.Enemies.Minotaur
{
    public class EnemyAttacksSetup : IEnemyAttacksSetup, IUpdatable
    {
        private readonly IEnemyTransformView _enemyTransformView;
        private DefaultAttack _defaultAttack;

        public EnemyAttacksSetup(IEnemyTransformView enemyTransformView)
        {
            _enemyTransformView = enemyTransformView ?? throw new ArgumentException("EnemyView can't be null");
        }
        
        public IEnumerable<IEnemyAttack> BuildEnemyAttacks()
        {
            _defaultAttack = new DefaultAttack(_enemyTransformView, 1f);
            return new List<IEnemyAttack> { _defaultAttack };
        }

        public void Update() => _defaultAttack?.Update();
    }
}