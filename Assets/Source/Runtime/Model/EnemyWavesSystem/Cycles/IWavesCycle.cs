namespace SwampAttack.Model.EnemyWavesSystem
{
    public interface IWavesCycle
    {
        void Start();
        bool IsCompleted { get; }
        bool IsStarted { get; }
    }
}