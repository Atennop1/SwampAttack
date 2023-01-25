using SwampAttack.Runtime.Model.HealthSystem;
using SwampAttack.Runtime.View.SliderValueChangers;

namespace SwampAttack.Runtime.View.Health
{
    public class PlayerHealthView : ViewWithSmoothSliderValueChanger, IHealthView
    {
        public void Visualize(IHealth health) 
            => ChangeSliderValue(health.Value, health.MaxValue);
    }
}