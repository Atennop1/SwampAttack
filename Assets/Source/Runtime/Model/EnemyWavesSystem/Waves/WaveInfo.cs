using SwampAttack.Tools;

namespace SwampAttack.Model.EnemyWavesSystem
{
    public readonly struct WaveInfo
    {
        public readonly int EnemyCount;
        public readonly float DelayBetweenEnemies;
        
        public WaveInfo(int enemyCount, float delayBetweenEnemies)
        {
            EnemyCount = enemyCount.TryThrowIfLessOrEqualsZero();
            DelayBetweenEnemies = delayBetweenEnemies.TryThrowIfLessOrEqualsZero();
        }
    }
}