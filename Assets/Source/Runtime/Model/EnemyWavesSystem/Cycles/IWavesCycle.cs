namespace SwampAttack.Runtime.Model.EnemyWavesSystem.Cycles
{
    public interface IWavesCycle
    {
        void Start();
        bool IsCompleted { get; }
        bool IsStarted { get; }
    }
}