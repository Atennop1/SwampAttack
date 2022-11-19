using System;
using NUnit.Framework;
using SwampAttack.Runtime.View.Health;

namespace SwampAttack.Tests.Health
{
    public class CreateHealthTests
    {
        [Test]
        public void CantCreateIncorrectHealth()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var nullViewHealth = new Runtime.Model.HealthSystem.Health(10, null);
                var negativeHealth = new Runtime.Model.HealthSystem.Health(-1, new NullHealthView());
            });
        }
    }
}