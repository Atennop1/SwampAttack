using UnityEngine;

namespace SwampAttack.Runtime.View.Shop
{
    public class NotEnoughMoneyView : MonoBehaviour, INotEnoughMoneyView
    {
        [SerializeField] private Animator _animator;
        private const string DISPLAY_ANIMATOR_NAME = "Show";
        private const string CLOSE_ANIMATOR_NAME = "Close";

        public void Display()
            => _animator.Play(DISPLAY_ANIMATOR_NAME);

        public void Close()
            => _animator.Play(CLOSE_ANIMATOR_NAME);
    }
}
