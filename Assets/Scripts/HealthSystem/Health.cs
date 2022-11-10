using System;

namespace SwampAttack.HealthSystem
{
    public sealed class Health : IHealth
    {
        public bool IsDead => _value <= 0;
        public bool CanTakeDamage => _value > 0;
        
        private int _value;

        public Health(int value)
        {
            if (value <= 0)
                throw new ArgumentException($"Can't create health with {value} hp");

            _value = value;
        }

        public void TakeDamage(int count)
        {
            if (!CanTakeDamage)
                throw new Exception($"Can't take damage to {GetType()}");

            if (_value <= 0)
                throw new ArgumentException($"Can't take {count} damage");

            _value -= count;
            UnityEngine.Debug.Log(_value);
        }
    }
}