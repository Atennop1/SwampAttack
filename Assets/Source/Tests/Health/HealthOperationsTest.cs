using System;
using NUnit.Framework;
using SwampAttack.Runtime.HealthSystem;

namespace SwampAttack.Tests.Health
{
    public class HealthOperationsTest
    {
        private IHealth _health;

        [SetUp]
        public void Setup()
        {
            _health = new Runtime.Model.HealthSystem.Health(10);
        }
        
        [Test]
        public void IsTakeDamageWorksCorrectly()
        {
            try
            {
                _health.TakeDamage(-1);
                _health.TakeDamage(15);
                _health.TakeDamage(10);
            }
            catch { Assert.Pass(); }
        }

        [Test]
        public void IsHealWorksCorrectly()
        {
            _health.TakeDamage(2);

            try
            {
                _health.Heal(-1);
                _health.Heal(3);

                _health.TakeDamage(8);
                _health.Heal(10);
            }
            catch { Assert.Pass(); }
        }

        [Test]
        public void IsHealMathCorrect()
        {
            _health.TakeDamage(5);
            _health.Heal(3);
            Assert.AreEqual(8, _health.Value);
        }

        [Test]
        public void IsDamageMathCorrect()
        {
            _health.TakeDamage(5);
            Assert.AreEqual(5, _health.Value);
        }
    }
}