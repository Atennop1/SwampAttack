using System;
using System.Collections.Generic;
using SwampAttack.Root;
using SwampAttack.View.EnemyWavesSystem;

namespace SwampAttack.Model.EnemyWavesSystem
{
    public sealed class WavesCycle : IWavesCycle, IUpdatable
    {
        public bool IsCompleted => _currentWaveNumber == _waves.Count;
        public bool IsStarted { get; private set; }
        
        private int _currentWaveNumber;
        private readonly List<IWave> _waves;
        
        private IWave _currentWave => _waves[_currentWaveNumber];
        private readonly IWavesCycleProgressView _progressView;
        
        public WavesCycle(List<IWave> waves, IWavesCycleProgressView progressView)
        {
            _waves = waves ?? throw new ArgumentException("Waves list can't be null");
            _progressView = progressView ?? throw new ArgumentException("ProgressView can't be null");
        }

        public void Start() 
            => IsStarted = true;

        public void Update()
        {
            if (IsCompleted || !IsStarted)
                return;
            
            if (!_currentWave.IsStarted)
                _currentWave.Start();

            if (!_currentWave.IsCompleted) 
                return;
            
            _currentWaveNumber++;
            _progressView.Visualize(_currentWaveNumber, _waves.Count);
        }
    }
}