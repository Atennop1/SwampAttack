namespace SwampAttack.HealthSystem
{
    public interface IHealth
    {
        bool CanTakeDamage { get; }
        bool IsDead { get; }
        void TakeDamage(int count);
    }
}