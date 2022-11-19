namespace SwampAttack.Runtime.Model.EnemyWavesSystem.Waves
{
    public interface IWave
    {
        void Start();
        bool IsCompleted { get; }
        bool IsStarted { get; }
    }
}