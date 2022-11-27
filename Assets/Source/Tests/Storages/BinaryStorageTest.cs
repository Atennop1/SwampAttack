using NUnit.Framework;
using SwampAttack.Runtime.Tools.SaveSystem;

namespace SwampAttack.Tests.Storages
{
    public class BinaryStorageTest
    {
        [Test]
        public void IsWorkingCorrect()
        {
            var storage = new BinaryStorage();
            storage.Save(76, "test");
            
            if (storage.Load<int>("test") == 76)
                Assert.Pass();
        }
    }
}