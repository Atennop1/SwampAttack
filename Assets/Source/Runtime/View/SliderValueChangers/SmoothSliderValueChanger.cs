using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using SwampAttack.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace SwampAttack.View.SliderValueChangers
{
    public class SmoothSliderValueChanger : ISliderValueChanger
    {
        private readonly float _timeOfChanging;
        private readonly Slider _slider;
        
        private UniTask _changingTask;
        private CancellationTokenSource _cancellationTokenSource;
        
        public void ChangeValue(float newValue)
        {
            newValue.TryThrowIfLessThanZero();
            
            if (_changingTask.Status == UniTaskStatus.Pending)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource = new CancellationTokenSource();
            }
            
            _changingTask = ChangingTask(newValue, _cancellationTokenSource.Token);
        }

        private async UniTask ChangingTask(float newValue, CancellationToken token)
        {
            float timer = 0;
            var valueOnStart = _slider.value;
            
            while (timer < _timeOfChanging)
            {
                if (token.IsCancellationRequested)
                    break;
                
                _slider.value = Mathf.Lerp(valueOnStart, newValue, timer / _timeOfChanging);
                timer += Time.fixedDeltaTime;
                await UniTask.WaitForFixedUpdate();
            }
        }

        public SmoothSliderValueChanger(Slider slider, float timeOfChanging)
        {
            _timeOfChanging = timeOfChanging.TryThrowIfLessThanZero();
            _slider = slider ? slider : throw new ArgumentException("Slider can't be null");
            _cancellationTokenSource = new CancellationTokenSource();
        }
    }
}