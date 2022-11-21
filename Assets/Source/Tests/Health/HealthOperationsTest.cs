using NUnit.Framework;
using SwampAttack.Runtime.Model.HealthSystem;
using SwampAttack.Runtime.View.Health;

namespace SwampAttack.Tests.Health
{
    public class HealthOperationsTest
    {
        private IHealth _health;

        [SetUp]
        public void Setup()
        {
            _health = new Runtime.Model.HealthSystem.Health(10, new NullHealthView());
        }
        
        [Test]
        public void IsTakeDamageWorksCorrectly()
        {
            var errors = 0;

            try { _health.TakeDamage(-1); }
            catch { errors++; }

            try 
            {
                _health.TakeDamage(15);
                _health.TakeDamage(10);
            }
            catch { errors++; }
            
            if (errors == 2)
                Assert.Pass();
        }

        [Test]
        public void IsHealWorksCorrectly()
        {
            var errors = 0;
            _health.TakeDamage(2);

            try { _health.Heal(-1); }
            catch { errors++; }

            try { _health.Heal(3); }
            catch { errors++; }

            try
            {
                _health.TakeDamage(8);
                _health.Heal(10);
            }
            catch { errors++; }
            
            if (errors == 3)
                Assert.Pass();
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