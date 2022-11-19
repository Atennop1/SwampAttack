using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwampAttack.Runtime.Factories;
using SwampAttack.Runtime.Model.AI.Enemies.Interfaces;

namespace SwampAttack.Runtime.Model.EnemyWavesSystem.Waves
{
    public sealed class Wave : IWave
    {
        public bool IsCompleted => _spawnedEnemies.Count != 0 && 
                                   _spawnedEnemies.All(enemy => enemy == null || enemy.Health.IsDead);
        public bool IsStarted { get; private set; }
        
        private readonly WaveInfo _waveInfo;
        private readonly EnemyFactory _enemyFactory;
        
        private readonly List<IEnemy> _spawnedEnemies = new();

        public Wave(WaveInfo waveInfo, EnemyFactory enemyFactory)
        {
            _waveInfo = waveInfo;
            _enemyFactory = enemyFactory ? enemyFactory : throw new ArgumentException("EnemyFactory can't be null");
        }

        public async void Start()
        {
            IsStarted = true;
            await StartSpawningCycle();
        }
        
        private async Task StartSpawningCycle()
        {
            while (IsStarted && !IsCompleted && _spawnedEnemies.Count < _waveInfo.EnemyCount)
            {
                _spawnedEnemies.Add(_enemyFactory.Create().Enemy);
                await Task.Delay((int)(_waveInfo.DelayBetweenEnemies * 1000));
            }
        }
    }
}