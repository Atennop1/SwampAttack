namespace SwampAttack.Runtime.View.EnemyWavesSystem
{
    public interface IWavesCycleProgressView
    {
        void Visualize(int completed, int maxValue);
    }
}