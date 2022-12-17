using System;
using SwampAttack.Runtime.Model.HealthSystem;
using UnityEngine;

namespace SwampAttack.Runtime.View.Health
{
    public sealed class HealthTransformView : MonoBehaviour, IHealthTransformView
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
            if (!_health.IsDead) 
                return;
            
            if (_deathEffect != null)
                Instantiate(_deathEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

        public bool CanHeal(int count) => _health.CanHeal(count);
        public void Heal(int count) => _health.Heal(count);
        
        public bool IsDead => _health.IsDead;
        public bool CanTakeDamage => _health.CanTakeDamage;
    }
}