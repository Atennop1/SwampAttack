using Sirenix.OdinInspector;
using SwampAttack.Runtime.Model.HealthSystem;
using UnityEngine;
using UnityEngine.UI;

namespace SwampAttack.Runtime.View.Health
{
    public class PlayerHealthView : SerializedMonoBehaviour, IHealthView
    {
        [SerializeField] private Slider _slider;
        
        public void Visualize(IHealth health)
        {
            _slider.value = (float)health.Value / (float)health.MaxValue;
        }
    }
}