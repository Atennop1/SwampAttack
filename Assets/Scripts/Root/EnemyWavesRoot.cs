using System.Collections.Generic;
using System.Threading.Tasks;
using SwampAttack.EnemyWavesSystem.Cycles;
using SwampAttack.EnemyWavesSystem.Waves;
using SwampAttack.Factories;
using SwampAttack.Root.Interfaces;
using SwampAttack.Root.SystemUpdates;
using UnityEngine;

namespace SwampAttack.Root
{
    public sealed class EnemyWavesRoot : CompositeRoot
    {
        [SerializeField] private EnemyFactory _enemyFactory;
        private SystemUpdate _systemUpdate;
        
        public override async void Compose()
        {
            await Task.Delay(1000);
            
            _systemUpdate = new SystemUpdate();
            var waveInfo = new WaveInfo(3, 2);
            
            var firstWave = new Wave(waveInfo, _enemyFactory);
            var secondWave = new Wave(waveInfo, _enemyFactory);

            var wavesCycle = new WavesCycle(new List<IWave> { firstWave, secondWave });
            _systemUpdate.Add(wavesCycle);
            
            wavesCycle.Start();
        }
        
        private void FixedUpdate() => _systemUpdate?.UpdateAll();
    }
}