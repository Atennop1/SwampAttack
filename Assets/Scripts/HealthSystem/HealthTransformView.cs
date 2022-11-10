using System;
using UnityEngine;

namespace SwampAttack.HealthSystem
{
    public sealed class HealthTransformView : MonoBehaviour
    {
        [SerializeField] private GameObject _deathEffect;
        private IHealth _health;

        public void Init(IHealth health)
        {
            _health = health ?? throw new ArgumentException("Can't init null health");
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
            if (!_health.IsDead) return;
            
            if (_deathEffect != null)
                Instantiate(_deathEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
        
        public bool IsDead => _health.IsDead;
        public bool CanTakeDamage => _health.CanTakeDamage;
    }
}