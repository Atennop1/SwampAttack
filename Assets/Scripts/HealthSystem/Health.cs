using System;

namespace SwampAttack.HealthSystem
{
    public sealed class Health : IHealth
    {
        private int _value = 0;

        public bool CanTakeDamage => _value > 0;

        public Health(int value)
        {
            if (value <= 0)
                throw new ArgumentException($"Can't create health with {value} hp");

            _value = value;
        }

        public void TakeDamage(int count)
        {
            if (!CanTakeDamage)
                throw new Exception($"Can't take damage to {this.GetType()}");

            if (_value <= 0)
                throw new ArgumentException($"Can't take {count} damage");

            _value -= count;
        }
    }
}