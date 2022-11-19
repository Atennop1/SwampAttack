using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.View.SliderValueChangers;

namespace SwampAttack.Runtime.View.Weapons
{
    public class DefaultWeaponBulletsView : ViewWithSmoothSliderValueChanger, IWeaponBulletsView
    {
        public void Visualize(IWeapon weapon) => ChangeSliderValue(weapon.Bullets, weapon.MaxBullets);
        private void Start() => Slider.value = Slider.maxValue;
    }
}