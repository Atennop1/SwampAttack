namespace SwampAttack.Runtime.View.EnemyWavesSystem
{
    public interface IWavesCycleProgressView
    {
        void Visualize(float completed, float maxValue);
    }
}