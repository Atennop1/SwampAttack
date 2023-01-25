using SwampAttack.Runtime.Model.HealthSystem;
using SwampAttack.Runtime.View.Health;

namespace SwampAttack.Tests.NullComponents.Health
{
    public class NullHealthTransformView : IHealthTransformView
    {
        public void Init(IHealth health) { }
        public void TakeDamage(int damage) { }

        public void Heal(int count) { }
        
        public bool CanHeal(int count) 
            => true;

        public bool IsDead 
            => false;
        
        public bool CanTakeDamage 
            => true;
    }
}