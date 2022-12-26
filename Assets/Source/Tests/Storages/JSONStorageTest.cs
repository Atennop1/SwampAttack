using NUnit.Framework;
using SwampAttack.Runtime.Tools.SaveSystem;

namespace SwampAttack.Tests.Storages
{
    public class JSONStorageTest
    {
        [Test]
        public void IsWorkingCorrect()
        {
            var jsonStorage = new JSONStorage();
            jsonStorage.Save(76, "Test.json");
            
            if (jsonStorage.Load<int>("Test.json") == 76)
                Assert.Pass();
        }
    }
}