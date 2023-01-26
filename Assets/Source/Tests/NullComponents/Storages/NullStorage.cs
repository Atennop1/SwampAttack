using System;
using SwampAttack.Tools;

namespace SwampAttack.Tests.NullComponents
{
    public class NullStorage : IStorage
    {
        public void Save<T>(T item, string path) { }
        public void DeleteSave(string path) { }
        
        public T Load<T>(string path) 
            => Activator.CreateInstance<T>();
        public bool Exists(string path) 
            => true;
    }
}