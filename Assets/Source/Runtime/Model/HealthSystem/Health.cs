using System;
using SwampAttack.Tools;
using SwampAttack.View.Health;

namespace SwampAttack.Model.HealthSystem
{
    public sealed class Health : IHealth
    {
        public int Value { get; private set; }
        public int MaxValue { get; }
        
        public bool IsDead => Value <= 0;
        public bool CanTakeDamage => !IsDead;
        private readonly IHealthView _healthView;

        public Health(int value, IHealthView healthView)
        {
            MaxValue = Value = value.TryThrowIfLessThanZero();
            _healthView = healthView ?? throw new ArgumentException("Health view can't be null");
        }

        public void TakeDamage(int count)
        {
            if (IsDead)
                throw new Exception("Can't take damage to dead health");
            
            Value -= count.TryThrowIfLessOrEqualsZero();
            _healthView.Visualize(this);
            
        }

        public void Heal(int count)
        {
            if (!CanHeal(count.TryThrowIfLessOrEqualsZero()))
                throw new InvalidOperationException($"Can't heal {count} hp. This is too much");
            
            if (IsDead)
                throw new ArgumentException("Can't heal a dead health!");

            Value += count;
            _healthView.Visualize(this);
        }
        
        public bool CanHeal(int count) 
            => count.TryThrowIfLessOrEqualsZero() + Value <= MaxValue;
    }
}