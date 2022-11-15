namespace SwampAttack.EnemyWavesSystem.Waves
{
    public readonly struct WaveInfo
    {
        public readonly int EnemyCount;
        public readonly float DelayBetweenEnemies;
        
        public WaveInfo(int enemyCount, float delayBetweenEnemies)
        {
            EnemyCount = enemyCount;
            DelayBetweenEnemies = delayBetweenEnemies;
        }
    }
}