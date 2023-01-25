using SwampAttack.Model.HealthSystem;
using SwampAttack.View.Health;

namespace SwampAttack.NullComponents
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