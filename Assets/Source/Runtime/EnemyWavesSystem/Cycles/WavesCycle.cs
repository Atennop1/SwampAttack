using System;
using System.Collections.Generic;
using SwampAttack.Runtime.EnemyWavesSystem.Waves;
using SwampAttack.Runtime.Root.SystemUpdates;

namespace SwampAttack.Runtime.EnemyWavesSystem.Cycles
{
    public sealed class WavesCycle : IWavesCycle, IUpdatable
    {
        public bool IsCompleted => _currentWaveNumber == _waves.Count;
        public bool IsStarted { get; private set; }
        
        private int _currentWaveNumber;
        private readonly List<IWave> _waves;
        private IWave _currentWave => _waves[_currentWaveNumber];
        
        public WavesCycle(List<IWave> waves)
        {
            _waves = waves ?? throw new ArgumentException("Waves list can't be null");
        }

        public void Start() => IsStarted = true;

        public void Update()
        {
            if (IsCompleted || !IsStarted)
                return;
            
            if (!_currentWave.IsStarted)
                _currentWave.Start();

            if (_currentWave.IsCompleted)
                _currentWaveNumber++;
        }
    }
}