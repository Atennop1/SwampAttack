using System;

namespace SwampAttack.Runtime.EnemyWavesSystem.Waves
{
    public readonly struct WaveInfo
    {
        public readonly int EnemyCount;
        public readonly float DelayBetweenEnemies;
        
        public WaveInfo(int enemyCount, float delayBetweenEnemies)
        {
            if (enemyCount < 0)
                throw new ArgumentException("EnemyCount can't be null");

            if (delayBetweenEnemies < 0)
                throw new ArgumentException("DelayBetweenEnemies can't be negative number");
            
            EnemyCount = enemyCount;
            DelayBetweenEnemies = delayBetweenEnemies;
        }
    }
}