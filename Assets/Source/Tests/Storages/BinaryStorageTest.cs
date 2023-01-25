using NUnit.Framework;
using SwampAttack.Tools;

namespace SwampAttack.Tests.Storages
{
    public class BinaryStorageTest
    {
        [Test]
        public void IsWorkingCorrect()
        {
            var storage = new BinaryStorage();
            storage.Save(76, "Test.binary");
            
            if (storage.Load<int>("Test.binary") == 76)
                Assert.Pass();
        }
    }
}