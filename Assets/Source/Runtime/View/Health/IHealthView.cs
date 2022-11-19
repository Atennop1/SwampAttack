using SwampAttack.Runtime.Model.HealthSystem;

namespace SwampAttack.Runtime.View.Health
{
    public interface IHealthView
    {
        void Visualize(IHealth health);
    }
}