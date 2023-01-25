using NUnit.Framework;
using SwampAttack.View.Health;

namespace SwampAttack.Tests.Health
{
    public class CreateHealthTests
    {
        [Test]
        public void CantCreateIncorrectHealth()
        {
            var errors = 0;

            try { var nullViewHealth = new Model.HealthSystem.Health(10, null); }
            catch { errors++; }

            try { var negativeHealth = new Model.HealthSystem.Health(-1, new NullHealthView()); }
            catch { errors++; }
            
            if (errors == 2)
                Assert.Pass();
        }
    }
}