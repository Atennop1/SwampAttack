namespace SwampAttack.HealthSystem
{
    public interface IHealth
    {
        bool CanTakeDamage { get; }
        void TakeDamage(int count);
    }
}