namespace SwampAttack.Runtime.EnemyWavesSystem.Waves
{
    public interface IWave
    {
        void Start();
        bool IsCompleted { get; }
        bool IsStarted { get; }
    }
}