using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace SwampAttack.Runtime.View.SliderValueChangers
{
    public class ViewWithSmoothSliderValueChanger : SerializedMonoBehaviour
    {
        [SerializeField] private float _timeOfVisualizing;
        [field: SerializeField] protected Slider Slider { get; private set; }
        private SmoothSliderValueChanger _sliderValueChanger;
        
        protected void ChangeSliderValue(int newValue, int maxValue)
        {
            var previousMaxValue = Slider.maxValue;
            Slider.maxValue = maxValue;
            
            Slider.value *= Slider.maxValue / previousMaxValue;
            _sliderValueChanger.ChangeValue(newValue);
        }
        
        private void Awake() => _sliderValueChanger = new SmoothSliderValueChanger(Slider, _timeOfVisualizing);
    }
}