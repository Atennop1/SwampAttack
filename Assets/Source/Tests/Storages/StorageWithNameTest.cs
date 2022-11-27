using NUnit.Framework;
using SwampAttack.Runtime.Model.Wallet;
using SwampAttack.Runtime.Tools.SaveSystem;

namespace SwampAttack.Tests.Storages
{
    public class StorageWithNameTest
    {
        [Test]
        public void CantCreateInvalidStorage()
        {
            try { var storage = new StorageWithNames<IMoney, int>(null); }
            catch { Assert.Pass(); }
        }
        
        [Test]
        public void IsWorkingCorrect()
        {
            var storage = new StorageWithNames<IMoney, int>(new JSONStorage());
            storage.Save(76);
            
            if (storage.Load<int>() == 76)
                Assert.Pass();
        }
    }
}