using SwampAttack.Model.HealthSystem;

namespace SwampAttack.View.Health
{
    public class NullHealthView : IHealthView
    {
        public void Visualize(IHealth health) { }
    }
}