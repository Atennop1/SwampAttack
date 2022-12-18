using System;
using SwampAttack.Runtime.Tools.SaveSystem;

namespace SwampAttack.Tests.NullComponents.Storages
{
    public class NullStorage : IStorage
    {
        public void Save<T>(T item, string path) { }
        public T Load<T>(string path) => Activator.CreateInstance<T>();
        public bool Exists(string path) => true;
        public void DeleteSave(string path) { }
    }
}