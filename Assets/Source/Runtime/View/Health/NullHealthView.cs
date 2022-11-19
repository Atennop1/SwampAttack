using SwampAttack.Runtime.Model.HealthSystem;

namespace SwampAttack.Runtime.View.Health
{
    public class NullHealthView : IHealthView
    {
        public void Visualize(IHealth health) { }
    }
}