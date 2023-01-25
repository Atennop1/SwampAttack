using SwampAttack.Model.HealthSystem;
using SwampAttack.View.SliderValueChangers;

namespace SwampAttack.View.Health
{
    public class PlayerHealthView : ViewWithSmoothSliderValueChanger, IHealthView
    {
        public void Visualize(IHealth health) 
            => ChangeSliderValue(health.Value, health.MaxValue);
    }
}