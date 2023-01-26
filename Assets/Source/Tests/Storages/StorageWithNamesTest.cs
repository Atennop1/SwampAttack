using NUnit.Framework;
using SwampAttack.Tests.NullComponents;
using SwampAttack.Tools;

namespace SwampAttack.Tests.Storages
{
    public class StorageWithNamesTest
    {
        [Test]
        public void IsWorkingCorrect()
        {
            var storage = new StorageWithNames<ITestMoney, int>();
            storage.Save(76);
            
            if (storage.Load<int>() == 76)
                Assert.Pass();
        }
    }
}