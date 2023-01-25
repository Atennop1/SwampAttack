using System;
using SwampAttack.Tools;

namespace SwampAttack.NullComponents
{
    public class NullStorage : IStorage
    {
        public void Save<T>(T item, string path) { }
        public T Load<T>(string path) => Activator.CreateInstance<T>();
        public bool Exists(string path) => true;
        public void DeleteSave(string path) { }
    }
}