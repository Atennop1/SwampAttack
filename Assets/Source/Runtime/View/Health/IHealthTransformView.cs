using SwampAttack.Model.HealthSystem;

namespace SwampAttack.View.Health
{
    public interface IHealthTransformView
    {
        void Init(IHealth health);
        void TakeDamage(int damage);

        bool CanHeal(int count);
        void Heal(int count);

        bool IsDead { get; }
        bool CanTakeDamage { get; }
    }
}