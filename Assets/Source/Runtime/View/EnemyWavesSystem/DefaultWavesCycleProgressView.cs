using System.Threading;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

namespace SwampAttack.Runtime.View.EnemyWavesSystem
{
    public class DefaultWavesCycleProgressView : SerializedMonoBehaviour, IWavesCycleProgressView
    {
        [SerializeField] private float _timeOfVisualizing;
        [SerializeField] private Slider _slider;
        
        private UniTask _visualizingTask;
        private CancellationTokenSource _cancellationTokenSource;

        public void Visualize(float completed, float maxValue)
        {
            if (_visualizingTask.Status == UniTaskStatus.Pending)
                _cancellationTokenSource.Cancel();
            
            _visualizingTask = VisualizeTask(completed / maxValue, _cancellationTokenSource.Token);
        }

        private async UniTask VisualizeTask(float newValue, CancellationToken token)
        {
            float timer = 0;
            var valueOnStart = _slider.value;

            while (timer < _timeOfVisualizing)
            {
                if (token.IsCancellationRequested)
                    break;
                
                _slider.value = Mathf.Lerp(valueOnStart, newValue, timer / _timeOfVisualizing);
                timer += Time.fixedDeltaTime;
                await UniTask.WaitForFixedUpdate();
            }
        }

        private void Awake()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _slider.value = 0;
        }
    }
}