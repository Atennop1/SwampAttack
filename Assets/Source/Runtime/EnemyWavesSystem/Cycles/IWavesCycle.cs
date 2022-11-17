namespace SwampAttack.Runtime.EnemyWavesSystem.Cycles
{
    public interface IWavesCycle
    {
        void Start();
        bool IsCompleted { get; }
        bool IsStarted { get; }
    }
}