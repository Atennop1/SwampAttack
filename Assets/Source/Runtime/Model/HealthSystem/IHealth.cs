namespace SwampAttack.Runtime.Model.HealthSystem
{
    public interface IHealth
    {
        int Value { get; }
        int MaxValue { get; }
        bool IsDead { get; }
        
        bool CanTakeDamage { get; }
        void TakeDamage(int count);

        bool CanHeal(int count);
        void Heal(int count);
    }
}