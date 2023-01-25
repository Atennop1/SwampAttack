namespace SwampAttack.Model.EnemyWavesSystem
{
    public interface IWave
    {
        void Start();
        bool IsCompleted { get; }
        bool IsStarted { get; }
    }
}