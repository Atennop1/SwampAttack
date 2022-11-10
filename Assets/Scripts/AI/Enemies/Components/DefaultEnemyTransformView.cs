using SwampAttack.AI.Enemies.Interfaces;
using UnityEngine;

namespace SwampAttack.AI.Enemies.Components
{
    public sealed class DefaultEnemyTransformView : MonoBehaviour, IEnemyTransformView
    {
        [SerializeField] private Animator _animator;
        public Transform Transform => transform;

        public void PlayAnimation(string key)
        {
            _animator.Play(key);
        }
    }
}